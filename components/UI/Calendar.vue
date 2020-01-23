<template>
<div>

    <div>
        <DatePicker 
          class="mb-2 mr-sm-2 mb-sm-0"
            :minimumView="'month'" 
            :maximumView="'year'"
            placeholder="see other dates" 
            id="date" 
            :bootstrap-styling="true" 
            :full-month-name="true"
            format="MMMM yyyy"
            :clearButton="true"
            @cleared="dateHasBeenCleared"
            @selected="hasChangedDate" />
    </div>

    <FullCalendar 
    defaultView="dayGridMonth" 
    :plugins="calendarPlugins"
    :events="events"
    :showNonCurrentDates="false"
    :displayEventTime="false"
    eventTextColor="#fff"
    :firstDay="1"
    :header="{left:'',center:'',right:''}"
    @dateClick="hasClickedDate"
    @eventClick="hasSelectEvent"
    @dayRender="onDayRender" />
</div>
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
        ,onDayRender(dayRenderInfo){
            if (dayRenderInfo.date.getUTCDay()===0 || dayRenderInfo.date.getUTCDay()===6){
                dayRenderInfo.el.bgColor=c.CALENDAR_COLORS.WEEKEND
            }
        }
        ,dateHasBeenCleared(){
            this.$emit(c.EMIT_ACTIONS.HAS_CLEARED_DATE)            
        }
        ,hasChangedDate(d){
            this.$emit(c.EMIT_ACTIONS.HAS_CHANGED_DATE, d)
        }
    }
}
</script>
<style>

@import '~/node_modules/@fullcalendar/core/main.css';
@import '~/node_modules/@fullcalendar/daygrid/main.css';

</style>
