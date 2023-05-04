# REST API example application

This is a backend application for scrutz.

This is an Asp.net core 6 project 

## Prerequirements

* Visual Studio 20
* Asp.net core 
* SQL Server

## How To Run

* Open solution in Visual Studio 
* Build the project.
* Run the application.

# REST API

The REST API to the Scrutz app is described below.

## Campaigns

### Request

`GET /Campaign/`

    | HTTP Verbs | Endpoints | Action |
    | GET | https://scrutzbackend.azurewebsites.net/api/Campaign | Retrieve a list of all the Campaigns |

### Curl
    curl -X 'GET' \
    'https://scrutzbackend.azurewebsites.net/api/Campaign' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer Access Token'   

### Response Body
    [
        {
            "id": 0,
            "campaignName": "string",
            "campaignDescription": "string",
            "startDate": "2023-05-04T14:18:52.073Z",
            "endDate": "2023-05-04T14:18:52.073Z",
            "recieveDailyDigest": true,
            "linkedKeywords": [
            "string"
            ],
            "dailyDigestTime": "2023-05-04T14:18:52.073Z",
            "campaignStatus": "Active"
        },
        {
            "id": 0,
            "campaignName": "string",
            "campaignDescription": "string",
            "startDate": "2023-05-04T14:18:52.073Z",
            "endDate": "2023-05-04T14:18:52.073Z",
            "recieveDailyDigest": true,
            "linkedKeywords": [
            "string"
            ],
            "dailyDigestTime": "2023-05-04T14:18:52.073Z",
            "campaignStatus": "Active"
        }
    ]

## Create a new campaign

### Request

`POST /Campaign/`

    | HTTP Verbs | Endpoints | Action |
    | GET | https://scrutzbackend.azurewebsites.net/api/Campaign | Create a new Campaigns |

### Curl
    curl -X 'POST' \
    'https://scrutzbackend.azurewebsites.net/api/Campaign' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer Access Token\
    -H 'Content-Type: application/json' \
    -d '{
    "campaignName": "string",
    "campaignDescription": "string",
    "startDate": "2023-05-04T13:42:25.070Z",
    "endDate": "2023-05-04T13:42:25.070Z",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "string",
        "string",
        "string"
    ],
    "dailyDigestTime": "2023-05-04T13:42:25.070Z"
    }    

### Response Body

    {
    "id": 9,
    "campaignName": "string",
    "campaignDescription": "string",
    "startDate": "2023-05-04T13:42:25.07Z",
    "endDate": "2023-05-04T13:42:25.07Z",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "string",
        "string",
        "string"
    ],
    "dailyDigestTime": "2023-05-04T13:42:25.07Z",
    "campaignStatus": "InActive"
    }



## Get a specific Campaign

### Request

`GET /Campaign/id`

    | HTTP Verbs | Endpoints | Action |
    | GET | https://scrutzbackend.azurewebsites.net/api/Campaign/3 | Get a specific Campaign details |


### Curl
    curl -X 'GET' \
    'https://scrutzbackend.azurewebsites.net/api/Campaign/3' \
    -H 'accept: */*' \
    -H 'Authorization: Bearer Access token '

### Response Body
    {
    "id": 3,
    "campaignName": "Swift4g",
    "campaignDescription": "Campaign for 4g",
    "startDate": "2023-05-02T14:28:12.545",
    "endDate": "2023-05-02T14:28:12.545",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "Data",
        "Airtime",
        "Port"
    ],
    "dailyDigestTime": "2023-05-02T14:28:12.545",
    "campaignStatus": "InActive"
    }
  


## Edit an existing Campaign

### Request

`PUT /Campaign/id`

    | HTTP Verbs | Endpoints | Action |
    | PUT | https://scrutzbackend.azurewebsites.net/api/Campaign/3 | Get a specific Campaign details |

### Curl
    curl -X 'PUT' \
    'https://scrutzbackend.azurewebsites.net/api/Campaign/3' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer Access token ' \
    -H 'Content-Type: application/json' \
    -d '{
    "campaignName": "string",
    "campaignDescription": "string",
    "startDate": "2023-05-04T14:39:47.838Z",
    "endDate": "2023-05-04T14:39:47.838Z",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "string"
    ],
    "dailyDigestTime": "2023-05-04T14:39:47.838Z"
    }'    

### Response Body

    {
    "id": 9,
    "campaignName": "string",
    "campaignDescription": "string",
    "startDate": "2023-05-04T14:39:47.838Z",
    "endDate": "2023-05-04T14:39:47.838Z",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "string"
    ],
    "dailyDigestTime": "2023-05-04T14:39:47.838Z",
    "campaignStatus": "InActive"
    }

## Delete a Campaign

### Request

` Delete Campaign/id/`

    | HTTP Verbs | Endpoints | Action |
    | DELETE | https://scrutzbackend.azurewebsites.net/api/Campaign/3 | Delete a Campaign |

### Curl
    curl -X 'DELETE' \
    'https://scrutzbackend.azurewebsites.net/api/Campaign/3' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer Access Token'


### Response body

    {
    "id": 9,
    "campaignName": "string",
    "campaignDescription": "string",
    "startDate": "2023-05-04T14:39:47.838",
    "endDate": "2023-05-04T14:39:47.838",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "string"
    ],
    "dailyDigestTime": "2023-05-04T14:39:47.838",
    "campaignStatus": "InActive"
    }   

## Update Active Status

### Request

`GET /Campaign/UpdateActiveStatus/Id?activeStatus=Stauts`
`Status = Active or InActive`

    | HTTP Verbs | Endpoints | Action |
    | UPDATE | https://scrutzbackend.azurewebsites.net/api/Campaign/4?activeStatus=Active | Update Active Status |


### Curl
    curl -X 'PUT' \
    'https://localhost:7135/api/Campaign/UpdateActiveStatus/4?activeStatus=Active' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer AccessToken'

### Response Body

    {
    "id": 4,
    "campaignName": "Swift4g",
    "campaignDescription": "Campaign for 4g",
    "startDate": "2023-05-02T14:28:12.545",
    "endDate": "2023-05-02T14:28:12.545",
    "recieveDailyDigest": true,
    "linkedKeywords": [
        "Data",
        "Airtime",
        "Port"
    ],
    "dailyDigestTime": "2023-05-02T14:28:12.545",
    "campaignStatus": "Active"
    }

