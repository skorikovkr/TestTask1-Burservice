function readFile(input) {
  let file = input.files[0];
  if (file == null)
    return;

  let reader = new FileReader();
  reader.readAsText(file);

  reader.onload = function() {
    let result = reader.result;
    textInFile.value = result;
    textContents.textContent = result;
  };
}