function initFilters(filters)
{
    $("#StartDateTxt, #EndDateTxt").mask("99/99/9999"); //add masking to our date fields

    var CategoryFilter = filters.Category;
    var StartDateFilter = filters.StartDate;
    var CityFilter = filters.City;
    var VenueFilter = filters.Venue;

    //If there is an advanced filter present then show the  hidden filters form
    if (CategoryFilter || StartDateFilter || CityFilter || VenueFilter) {
        //$('#AdvancedSearchForm').collapse('show'); //This is kind of irritating... Everytime it reloads it does the collapse animation..        
        $('#AdvancedSearchForm').addClass('in'); //this is better but still offers a small UFOC...
    }
}