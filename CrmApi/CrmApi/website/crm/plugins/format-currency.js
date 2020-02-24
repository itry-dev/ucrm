import Vue from 'vue'

export const format = function(value){
  if (!value) return ''
  if (typeof value !== 'number') {
    value=parseFloat(value)
  }
  
  value= value.toFixed(2).replace('.',',')+' €'

  return value
}

Vue.filter('format', format)