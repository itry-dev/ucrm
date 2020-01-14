<template>
    <FullCalendar 
    defaultView="dayGridMonth" 
    :plugins="calendarPlugins"
    :events="events"
    :showNonCurrentDates="false"
    :displayEventTime="false"
    :firstDay="1"
    @dateClick="hasClickedDate"
    @eventClick="hasSelectEvent" />
</template>
<script>
import c from '@/core/costants'
import FullCalendar from '@fullcalendar/vue'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from '@fullcalendar/interaction'

export default {
    components: {
        FullCalendar
    },
    data() {
        return {
            calendarPlugins: [ dayGridPlugin, interactionPlugin ]
        }
    }
    ,props:{
        events:{
            type:Array
        }
    }
    ,methods:{
        hasClickedDate(arg){
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_DATE, arg.date)
        }
        ,hasSelectEvent(info){
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_WORKEDHOURS, info.event.extendedProps.whId)            
        }
    }
}
</script>
<style>

@import '~/node_modules/@fullcalendar/core/main.css';
@import '~/node_modules/@fullcalendar/daygrid/main.css';

</style>