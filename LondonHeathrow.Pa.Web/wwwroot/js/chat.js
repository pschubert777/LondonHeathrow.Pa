"use strict";
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/pa-iot")
    .build();

const devicesTableBody = document.getElementById("devices-table-body");



const addIotDevice = (deviceId) => {
    var row = document.createElement("tr");
    row.setAttribute("id", deviceId);

    var deviceIdElement = document.createElement("td");
    deviceIdElement.setAttribute("id", `${deviceId}-device-id`);
    deviceIdElement.innerText = deviceId;

    var lastPollTimeElement = document.createElement("td");
    lastPollTimeElement.setAttribute("id", `${deviceId}-last-poll-time`)
    lastPollTimeElement.innerText = new Date().toISOString();

    var statusElement = document.createElement("td");
    statusElement.setAttribute("id", `${deviceId}-status`);
    statusElement.innerText = "Online";

    row.appendChild(deviceIdElement);
    row.appendChild(lastPollTimeElement);
    row.appendChild(statusElement);

    devicesTableBody.appendChild(row);
}

const updateIotDeviceStatus = (status, deviceId) => {

    const device = devicesTableBody.querySelector(`#${deviceId}`);

    const statusElement = device.querySelector(`#${deviceId}-status`);
    statusElement.innerText = status;
}


connection.on("RecieveDeviceHearbeat", (deviceId) => {

    const device = devicesTableBody.querySelector(`#${deviceId}`);

    if (device) {
        const lastPollTimeElement = device.querySelector(`#${deviceId}-last-poll-time`);

        lastPollTimeElement.innerText = new Date().toISOString();
    }
    else {
        addIotDevice(deviceId);
    }

});

connection.on("RecieveDeviceConnected", (deviceId) => {

    addIotDevice(deviceId)
});

connection.on("RecieveDeviceReconnected", (deviceId) => {
    const device = devicesTableBody.querySelector(`#${deviceId}`);

    if (device) {
        updateIotDeviceStatus("Online", deviceId);
    }
    else {
        addIotDevice(deviceId);
    }


});

connection.on("RecieveDeviceDisconnected", (deviceId) => {
    updateIotDeviceStatus("Offline", deviceId);
});


(async () => {

    await connection.start();

    await connection.invoke("RecieveClientConnected");

})();



