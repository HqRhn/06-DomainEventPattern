# 06-DomainEventPattern

**Raising an event to send order confirmation email to customer, after the order is successfully created**

**Create a OrderCreated Event:**

![Capture](https://github.com/HqRhn/05-.Net6-RepositoryPattern-MiddlewareUseCase-MovieCatalog/assets/141786593/84ba676d-b205-4852-8909-f229c3b4d282)

**Raise the OrderCreated Event after the order is created:**

![Capture](https://github.com/HqRhn/05-.Net6-RepositoryPattern-MiddlewareUseCase-MovieCatalog/assets/141786593/593eaac9-6524-4dd8-97b8-b8026e38997a)
![Capture](https://github.com/HqRhn/05-.Net6-RepositoryPattern-MiddlewareUseCase-MovieCatalog/assets/141786593/50909e47-364a-4acf-aa91-82e49787e167)
![Capture](https://github.com/HqRhn/05-.Net6-RepositoryPattern-MiddlewareUseCase-MovieCatalog/assets/141786593/3f8d9464-7299-4290-88ec-1fffffd31ed2)

**Handle the event implementation**
![Capture](https://github.com/HqRhn/05-.Net6-RepositoryPattern-MiddlewareUseCase-MovieCatalog/assets/141786593/8f1e4e8f-b2c0-490a-88e5-465eceaceb68)

**Finally, publish the event.(IPublish from mediatR library can be used to publish the events)**
