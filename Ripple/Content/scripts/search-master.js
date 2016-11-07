/**
 * ripple - This is a demonstration for Ripple Web
 * @version v1.0.0
 * @link https://github.com/bdm4/Ripple-Web-Search/
 * @author Ben Margevicius
 * Copyright 2016.  licensed.
 * Built: Mon Nov 07 2016 12:49:25 GMT-0500 (Eastern Standard Time).
 */
function initFilters(filters)
{
    $("#StartDateTxt, #EndDateTxt").mask("99/99/9999");

    var CategoryFilter = filters.Category;
    var StartDateFilter = filters.StartDate;
    var CityFilter = filters.City;
    var VenueFilter = filters.Venue;
    console.log("here", filters);

    if (CategoryFilter || StartDateFilter || CityFilter || VenueFilter) {
        $('#AdvancedSearchForm').collapse('show'); //This is kind of irritating... Everytime it reloads it does the collapse animation.. 
    }
}
function initresults() {
    
}
function initdetails()
{

}
$(function () {
    console.log("I am running jquery: ", $.fn.jquery);  
});