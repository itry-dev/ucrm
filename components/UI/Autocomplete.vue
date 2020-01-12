<template>
  <div class="autocomplete">
    <input
        class="form-control"
        placeholder="Start typing"
        type="text"
        v-model="search"
        @input="onChange" />
    <ul 
    v-show="isOpen"
    class="autocomplete-results">
        <li
            class="loading"
            v-if="isLoading">
            Loading results...
        </li>
        <li
            v-for="(result, i) in results"
            :key="i"
            class="autocomplete-result"
            @click="setResult(result)">
        {{ result[dataText] }}
        </li>
    </ul>
  </div>
</template>
<script>
  export default {
    name: 'autocomplete'
    ,props: {
      items: {
        type: Array,
        required: false,
        default: () => [],
      }
      ,initialValue:{
          type:Object,
          required:false
      }
      ,isAsync: {
        type: Boolean,
        required: false,
        default: false,
      }
      ,dataText:{
          type:String,
          required:true
      }
      ,dataValue:{
          type:String,
          required:true
      }
    }
    ,data() {
      return {
        search: '',
        results: [],
        isOpen: false,
        isLoading:false
      };
    }
    ,mounted(){
    }
    ,methods: {
        onChange() {
            // Let's warn the parent that a change was made
            if (this.search.length < 3) return;

            this.$emit('is-typing', this.search);

            // Is the data given by an outside ajax request?
            if (this.isAsync) {
                this.isLoading = true;
            } else {
                // Data is sync, we can search our flat array
                this.filterResults();
                this.isOpen = true;
            }
        }
        ,filterResults() {
            this.results = this.items.filter(item => item[this.dataText].toLowerCase().indexOf(this.search.toLowerCase()) > -1);
        }
        ,setResult(result) {
            this.search = result[this.dataText];
            this.isOpen = false;
            this.$emit('has-clicked-result', result);

        }
    }
    ,watch: {
      // Once the items content changes, it means the parent component
      // provided the needed data
      items: function (value, oldValue) {
        // we want to make sure we only do this when it's an async request
        if (this.isAsync) {
          this.results = value;
          this.isOpen = true;
          this.isLoading = false;
        }
      },
      initialValue: function(value, oldValue){
        this.setResult(this.initialValue)
      }
    }
  };
</script>
<style>
  .autocomplete {
    position: relative;
  }

  .autocomplete-results {
    padding: 0;
    margin: 0;
    border: 1px solid #eeeeee;
    height: 120px;
    overflow: auto;
  }

  .autocomplete-result {
    list-style: none;
    text-align: left;
    padding: 4px 2px;
    cursor: pointer;
  }

  .autocomplete-result:hover {
    background-color: #4AAE9B;
    color: white;
  }
</style>