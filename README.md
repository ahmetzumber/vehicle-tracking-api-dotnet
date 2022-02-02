# Vehicle Tracking API
This API provides CRUD operations for vehicle tracking system web api.

`Frontend repo: ` [vehicle-tracking-system-react]('https://github.com/ahmetzumber/vehicle-tracking-system-react')

## Rules
-  If user try to remove any company, vehicles of that company and tracking reports of that 
vehicles will be removed.
- If user try to remove any vehicle type, vehicles of that type will be removed.
- A company can own more than one vehicle.
- A vehicle can not own more than one company or type.
- If any vehicle will be removed, its tracking report will be removed.

## Modals
- `Vehicle:` This model stands for a vehicle that will be tracked. It has ID, name(plate), 
vehicle type, tracking ID and company ID properties.
- `Vehicle Types:` This model stands for a vehicle types that will be tracked. It has ID and 
name properties.
- `Company:` This model stands for a company that has vehicles. It has ID, company name 
and location properties.
- `TrackingDetail:` This model is stands for a tracking informations about related vehicles. It 
has ID, vehicle ID, tracking location, tracking date and description that about tracking 
moment properties.

## Controllers
- `VehicleController:` This object handles functionality and CRUD operations for vehicle 
modal and it manages data passing to related views.
- `VehicleTypeController:` This object handles functionality and CRUD operations for 
vehicle types modal and it manages data passing to related views.
- `CompanyController:` This object handles functionality and CRUD operations for 
company modal and it manages data passing to related views.
- `Tracking_DetailsController:` This object handles functionality and CRUD operations for 
tracking detail modal and it manages data passing to related views.
