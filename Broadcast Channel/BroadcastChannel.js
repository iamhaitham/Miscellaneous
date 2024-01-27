const channel = new BroadcastChannel("myChannel");
const messageDictionary = {
  createElement: "createElement",
  alert: "alert"
};
const createElementButton = document.getElementById("createElementButton");
const alertButton = document.getElementById("alertButton");
const disconnect = document.getElementById("disconnectButton");
let counter = 0;


// Handlers
const handleCreateElement = (content) => {
  const paragraph = document.createElement("p");
  const node = document.createTextNode(content);
  paragraph.appendChild(node);

  const section = document.getElementsByTagName("section")[0];
  section.appendChild(paragraph);
};

const handleAlert = (content) => alert(content);


// Event Listeners
createElementButton.addEventListener("click", () => channel.postMessage({ 
  type: messageDictionary.createElement,
  content: ++counter
}));

alertButton.addEventListener("click", () => channel.postMessage({
  type: messageDictionary.alert,
  content: "I have received an alert message"
}));

disconnect.addEventListener("click", () => {
  channel.close();
})

channel.onmessage = (event) => {
  if(event.data.type === messageDictionary.createElement)
    handleCreateElement(`This is paragraph number: ${event.data.content}`);
  else if (event.data.type === messageDictionary.alert)
    handleAlert(event.data.content);
};
