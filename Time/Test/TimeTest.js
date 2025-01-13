import http from 'k6/http';
import { check, sleep } from 'k6';

export default function () {
   
    const payloads = [
        JSON.stringify({
            "internalId": "teste",
            "taskId": 1,
            "accountId": 2,
            "date": "2024-08-13T04:05:43.135Z",
            "description": "string",
            "startTime": "04:05:43",
            "finishTime": "10:05:43",
            "onSite": false
        }),
        JSON.stringify({
            "internalId": "internalId",
            "taskId": 1,
            "accountId": 3,
            "date": "2024-08-13T04:05:43.135Z",
            "description": "string",
            "startTime": "10:05:43",
            "finishTime": "12:05:43",
            "onSite": true
        }),
        JSON.stringify({
            "internalId": "string",
            "taskId": 1,
            "accountId": 1,
            "date": "2024-08-13T04:05:43.135Z",
            "description": "string",
            "startTime": "04:05:43",
            "finishTime": "13:05:43",
            "onSite": false
        }),
        JSON.stringify({
            "internalId": "string",
            "taskId": 1,
            "accountId": 5,
            "date": "2024-08-13T04:05:43.135Z",
            "description": "string",
            "startTime": "12:05:43",
            "finishTime": "17:05:43",
            "onSite": false
        })
    ];
    for (let i = 0; i < payloads.length; i++) {
        let response = http.post('http://localhost:8000/Appointment', payloads[i], {
            headers: { 'Content-Type': 'application/json' }
        });
        check(response, { 'is status 201': (r) => r.status === 201 });
        sleep(1);  
    }
}