API TREE
========

# API Root
/api/v1/stations/
     ../powerlines/
     ../equipments/
     ../users/
     ../offices/
     ../addresses/
     ../manufacturers/


# stations
/api/v1/stations/                                               : station list
              ../{code}                                         : station item
              ../{code}/powerlines/                             : powerline list for station item
              ../{code}/transformers/
              ../{code}/panels/
              ../{code}/..
              ../?page=x
                 &pageSize=y
                 &type=a
                 &voltageRatio=b
                 &sourcePowerLineCode=c
                 &isPublic=d


# powerlines
/api/v1/powerlines/
                ../{code}
                ../{code}/stations/
                ../{code}/lineEquipments/
                ../{code}/..
                ../?page=x
                   &pageSize=y
                   &type=a
                   &voltage=b
                   &sourceStationCode=c

# equipments
/api/v1/equipments/
                ../{code}
             ?  ../{transformers}/
             ?  ../{panels}/
                ../{..}

# offices
/api/v1/offices/                                                : office list
             ../{code}                                          : office item
             ../{code}/suboffices
             ../{code}/users
             ../{code}/powerlines
             ../{code}/stations
             ../{code}/suboffices/{code2}
             ../{code}/suboffices/{code2}/suboffices
             ../{code}/suboffices/{code2}/users
             ../{code}/suboffices/{code2}/powerlines
             ../{code}/suboffices/{code2}/stations
             ..

# users
/api/v1/users/
           ../{code}
           ../{code}/{settings}


# addresses
/api/v1/address/countries
             ../states
             ../lgas

# manufacturers
/api/v1/manufacturers/
                   ../{code}
                   ../{code}/equipments