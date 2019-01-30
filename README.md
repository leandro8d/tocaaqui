<h3> Toca Aqui  </h3>
<p> Project developed in ASP.NET 2.0 core, Ionic 3 and Postgresql. </p>
<p> <h3> Folder Structure </h3> </p>
<pre>
<b> Source /Application.Mobile </b> - Ionic project files.
<b> Source /Application.Web </b> - .net core project with controllers
<b> Source /Domain </b> --Project with Domain Files (Entities and Dtos)
<b> Source /Repository </b> --Project with repositories of each entity and connection context.
<b> Source /Service /Mappings </b> --Place where you find table mappings.
<b> Source /Core</b> --Place with the configuration of each layer.
</pre>
<p> <h3> Design Patterns Used </h3> </p>
<pre>
DTO - Used to only traffic information required for interface.
Singleton - Unique creation of an object, impossible to be instantiated more than 1 time.
"DDD" - Project structuring, with application layer, repository, service and Core.
</pre>
<p> <h3> Important Points </h3> </p>
<pre>
<b> Source / Core / EntityBase.cs </b> - Abstract class where repositories should necessarily
inherit because the class DomainBase.cs contains generic methods that are used by all
repositories, such as CRUD operations, without the need for each repository to create
again, leaving only the specific queries of each repository.

<b>Repository</b> - These are classes that each entity has, to make specific queries to the database.

<b>Entities</b> - Mirror of DB entities, but with special methods and operations of aid and etc.
Consistency of the data.

<b>RepositoryBase.cs</b> --Connection database with database,.
The concept of singleton was used so that any project that needs to use the BD,
create another connection, which takes the active project connection.

</pre>
