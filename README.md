API Anrop:

            //KRAV: To get all poeple in the database and to see their IDnumber
            app.MapGet("/allpeople", (IPersonHelper personHelper) => PersonHandler.ListPeople(personHelper));
            //Gets all the websites that is combined with the interest
            app.MapGet("/alllinksfrominterest", (int id, IInterestHelper interestHelper) => InterestHandler.ListLinks(id, interestHelper));
            //Gets all interest in the DB to see the IDnumbers
            app.MapGet("/allinterests", (IInterestHelper interestHelper) => InterestHandler.ListInterests(interestHelper));
            //KRAV: To see what interests the person have
            app.MapGet("/personinterests", (int id, IPersonHelper personHelper) => PersonHandler.GetPersonInterests(id, personHelper));
            // KRAV KRAV: Get all the links connected to the person depending on what interest the persons have.
            app.MapGet("/listlinksconnectedtopersons", (int personId, IPersonHelper personHelper) => PersonHandler.LinksConnectedToPersons(personId, personHelper));

            // KRAV: Adds people to your db
            app.MapPost("/addpeople", (PersonDto personDto, IPersonHelper personHelper) => PersonHandler.AddPerson(personDto, personHelper));
            // KRAV: Adds interests to your db
            app.MapPost("/addinterest", (InterestDto interestDto, IInterestHelper interestHelper) => InterestHandler.AddInterest(interestDto, interestHelper));
            // KRAV: To make a person be able to like/save an interest
            app.MapPost("/addpersoninterest", (int id, int interestId, IPersonHelper personHelper) => PersonHandler.AddPersonInterest(id, interestId, personHelper));
            // KRAV: Choose a person, this person can then choose an interest to then put in a link to be saved to that interest.
            app.MapPost("/AddLinkToInterest", (int personId, int interestId, LinkDto linkDto, IInterestHelper interestHelper) => InterestHandler.AddLinkToInterest(personId, interestId, linkDto, interestHelper));
            






Diagram
![DiagramProjectAPI](https://github.com/Shakejelly/APIProject/assets/110773165/3b59888d-1728-45fa-8911-c8a1959a7872)
ER Diagram

