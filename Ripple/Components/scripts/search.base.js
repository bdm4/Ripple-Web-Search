function initFilters(filters)
{
    $("#StartDateTxt, #EndDateTxt").mask("99/99/9999");

    var CategoryFilter = filters.Category;
    var StartDateFilter = filters.StartDate;
    var CityFilter = filters.City;
    var VenueFilter = filters.Venue;
    console.log("here", filters);

    if (CategoryFilter || StartDateFilter || CityFilter || VenueFilter) {
        //$('#AdvancedSearchForm').collapse('show'); //This is kind of irritating... Everytime it reloads it does the collapse animation..
        $('#AdvancedSearchForm').addClass('in');
    }
}