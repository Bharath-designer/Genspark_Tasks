const pictureInp = document.querySelector(".drop-container");
const filenamePreview = document.querySelector(".filename-preview");

pictureInp && pictureInp.addEventListener("dragover", (e) => {
    e.preventDefault()
})

pictureInp && pictureInp.addEventListener("drop", (e) => {
    e.preventDefault()
    filenamePreview.textContent 
    = e.dataTransfer.files[0].name + 
    ` (${(e.dataTransfer.files[0].size / 1024).toFixed(2)}KB)`
    console.log(e.dataTransfer.files[0]);
});