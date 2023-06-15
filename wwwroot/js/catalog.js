function tagsOnClickHandlerShow() {
    var catalogFilterTagDiv = document.querySelector(".catalogFilterTagDiv");
    var tagsChoosingMode = document.querySelector(".tagsChoosingMode");

    catalogFilterTagDiv.style.display = "none";
    tagsChoosingMode.style.display = "block";
}
function tagsOnClickHandlerHide() {
    var catalogFilterTagDiv = document.querySelector(".catalogFilterTagDiv");
    var tagsChoosingMode = document.querySelector(".tagsChoosingMode");

    catalogFilterTagDiv.style.display = "grid";
    tagsChoosingMode.style.display = "none";
}
function deleteAllTags() {
    alert("all tags deleted");
}
function tagsApplied() {
    alert("all tags appliead");
}