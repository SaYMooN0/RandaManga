function tagsOnClickHandlerShow() {
    var OtherFilters = document.querySelector(".allInfoInputForm");
    OtherFilters.style.display = "none";
    var catalogFilterTagDiv = document.querySelector(".catalogFilterTagDiv");
    var tagsChoosingMode = document.querySelector(".tagsChoosingMode");
    catalogFilterTagDiv.style.display = "none";
    tagsChoosingMode.style.display = "block";

}
function tagsOnClickHandlerHide() {
    var OtherFilters = document.querySelector(".allInfoInputForm");
    OtherFilters.style.display = "block";
    var catalogFilterTagDiv = document.getElementById("catalogFilterTagDiv");
    var tagsChoosingMode = document.querySelector(".tagsChoosingMode");
    catalogFilterTagDiv.style.display = "grid";
    tagsChoosingMode.style.display = "none";
    console.log(1);
}
function deleteAllTags() {
    alert("all tags deleted");
}
function tagsApplied() {
    alert("all tags appliead");
}