# Technical challange Weather API

## Look the challange here
    * Item 1 (https://docs.google.com/document/d/1XqSOmapSBmONGzvBVmK8zv-G_OOA38Bc/edit?usp=sharing&ouid=107534122392575418381&rtpof=true&sd=true)

## Structure of projects

| Name  | usage |
| ------------------------ |:---------------------------------------------------------------:|
| weather.api              | used to expose domain                                           |
| weather.domain           | domain is used to implement handlers and business logical       |
| weather.cache.redis      | service used to reduce latency between request and response     |
| weather.db.slqserver     | service used to getdata on database                             |
| weather.domain.test      | service used to test domain                                     |
| weather.domain.shared    | dll used to abstrac some domain utilities                       |
| weather.shared.logger    | dll used to abstrac some log utilities                          |


## Structure of paths

*1. some files about docker to use db and cache easy
```
use : docker-compose up -d --build
```
*2.src
**    1. Presentation - weather.api
**    2. Application - weather.domain 
**    3. Infraestructure - weather.db.slqserver/weather.cache.redis
**    4. Tests - weather.domain.test
**    5. Shared - weather.domain.shared/weather.shared.logger
**    6. (only in solution) - docker and db files.

## Design
Structure(https://drive.google.com/file/d/1yIGsf0Dy4UtiQsHkTmpcmkrmtUxvKQFw/view?usp=sharing)


