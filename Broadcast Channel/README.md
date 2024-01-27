# Broadcast Channel

## About
The Broadcast Channel API allows basic communication between browsing contexts (that is, windows, tabs, frames, or iframes) and workers on the same origin. See [MDN](https://developer.mozilla.org/en-US/docs/Web/API/Broadcast_Channel_API) for more information.

I am practicing the usage of this API with two files:
- An HTML file that provides three buttons.
- A JavaScript file that handles clicking events on those buttons.

I have not introduced any styling as it does not contribute to the purpose of this mini project at all.

## Usage example
1. Open "BroadcastChannel.html" on three tabs.
2. Click on "Create Element" button in the first tab. This will append a new paragraph to the other two tabs.
3. In the second tab, click on "Alert" button. The first and the third tabs will get alerts.
4. In the third tab, click on "Disconnect" button. This tab will not receive messages anymore.
5. Go to the first tab again, and click on "Alert" button. Only the second tab will now get the alert.

**Note**: The message-publisher tab does not get affected by the changes. Disconnecting from the channel will disconnect the current tab though.
