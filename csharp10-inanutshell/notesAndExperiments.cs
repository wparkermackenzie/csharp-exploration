// General development practices would have new namespaces and types defined in their on 
// files. These notes and experiments sit in a single file because it is easier to reference.

// The using directive (different than the using statement argh...) imports a namespace.
// Importing a namespace means that instead of writing System.Console.Writeline one can simply write
// Console.Writeline()
using System;

// Types are generally organized within namespaces
// - Namespaces can be nested
namespace csharp10_inanutOshell
{
  /*
  Notes from: 
  "C# In a Nutshell";Joseph Albahari; O'Reilly Media; 

  Linux: Installing the .NET6 SDK which provides the dotnet tool
    sudo apt-get install -y dotnet-sdk-6.0

    - dotnet --list-sdks
      - List the installed .NET SDKs
    - dotnet new console -n csharp10-inanutshell
      - Scaffolds a new console project, creating its basic directory structure
    - dotnet run csharp10-inanutshell
      - Builds and runs a program called csharp10-inanutshell
    - dotnet build csharp10-inanutshell
      - Builds the program without running it (output is placed in bin/debug)
    
  The .NET6 SDK comes with the dotnet tool.
  Create a new console application:
    

  Object oriented with a functional programming twist
    - All types are objects with common basic functionality
    - Interfaces are a specific abstract type forcing the developer to seperate state from behavior,
       interfaces can only define behavior. 
    - All functions are methods, members of a class. Members can be a regular method, properties (encapsulation
      of an object's state), or events which act on object state changes.
    - Functions can be treated as values, being passed to other functions. These are called delegates. 
      similar to a function pointer in C.

  Type Safety
    - The language enforces type safety (instances of types can only interact with instances of a similar type
      unless a protocol is defined which explicitly defines how different types interact). Most type safety
      is performed by static typing at compile time.
    - Type rules are strictly (strongly) enforced (e.g. it is an error to call a function with an floating
      point number when it expects an integer).

  Memory Management
    - For the most part the programmer (for better or for worse) no longer is concerned with explicitly 
      deallocating memory for an object; the Common Runtime Language has a garbage collector.

  Block Diagram of the Run Time Architecture & Terminology
    +-----------------------------------------------------+  
    |           User Application/Assembly                 | 
    +--------------------------+--------------------------+  ---      
    |     Application Layer    |     Application Layer    |  /|\
    +--------------------------+--------------------------+   |
    |                  Base Class Library                 |   +--- Runtime/Framework
    +-----------------------------------------------------+   |
    |               Common Language Runtime               |  \|/
    +-----------------------------------------------------+  ---

    - Runtime (also called a framework) is downloaded and installed on the host computer in order to run
      specific types of applications. It includes the Common Language Runtime, the Base Class Library, and 
      the application libraries/layers associated with the type of apps being run. 
      When writing an application, one targets a specific runtime which will provide the support needed to 
      run the application on the host machine.

    - Common Language Runtime (CLR) which is different then the runtime architecture (argh)
      - Runs on the device, interpretting the intermediate language into native machine code in a Just In Time
        fashion.
      - Responsible for essental services and interface to the operating system (e.g. memory management).

    - Intermediate language - The sources which make up the application are compiled into an intermediate
      language which can be run on any machine which has a Common Language Runtime supports C#/.NET

    - Base Class Library (BCL) provides core functionality to the higher application layer. The BCL is included
      with the Common Language Runtime.
      - examples: input/output processing, networking, concurrency, and parallel programming features

    - Application Layer - Additional libraries specific to the type of application being written
      Examples : Mobile application, desktop application, web service

    - Assembly - Contains the intermediate language making up the application as well as type information called
      metadata. The metadata allows the assembly to reference types in other assemblies at runtime. If one 
      wants to create a rube goldberg machine, the language allows the application to query the metadata at 
      runtime and even generate new intermediate language at runtime; this is called reflection. Seems to me
      this falls into the "just because you can doesn't mean you should" set of life decisions...
      - The C# compiler, compiles the source code into an assembly which can either be an application or a
        library. 
      - .NET6 assemblies *never* have a .exe extension, the assemblies are placed in Dynamic Linked Libraries.
        One can produce an executable; however, by default, this is only a platform specific native loader
        for starting the application which is in the dll assembly. Optionally, one can tell .NET6 to create
        a self-contained deployment which includes:
          - The loader
          - The application's assemblies
          - The .NET Runtime (instead of depending on the customer to download it to their system)

  The Provider of Runtimes : Microsoft
      - Microsoft is basically the largest provider of runtimes. They provide an open source Common Language
        Runtime and Base Class Library called .NET 6. 
      - .NET 6 is not preinstalled on Windows (why?) unlike its predecessor .NET Framework (a misnomer). 

  Plethora of runtime options:
    - For web development:
      - Application Layer : ASP.NET
      - CLR/BCL           : .NET6
      - Runs on           : Windows, Linux, macOS
    - For Windows Programs
      - Application Layer : Windows Desktop
      - CLR/BCL           : .NET6
      - Runs on           : Windows
    - For Mobile
      - Application Layer : MAUI      
      - CLR/BCL           : .NET6
      - Runs on           : iOS, Android, macOS, Windows10+
    - Windows 10+ Desktop and Device Applications
      - Application Layer : UWP
      - CLR/BCL           : .NET6
      - Runs on           : WIndows 10+ Devices

  Identifiers
    - Case sensitive, starting with a letter or underscore.
    - Conventions
      - camelCase
        - parameters
        - localVariables
        - privateFields
      - PascalCase
        - EverythingElse 

  Type Basics
    - Static methods are refered to using the type instead of the instance using the same dot notation. 
    - C# looks for a static method called Main in a class (there can only be one) as the entry point to the
    application. The Main function can return an integer and take an array of strings as parameters which 
    represents arguments to the program.
  */
internal interface Experiment
  {
    public string name {get; init;}
    public int run();
  }

static class Program
  {

    static int Main(string[] args)
    {
      Console.WriteLine("The start of the program");
      return(0);
    }
  }

  /*
    - C# types are either value types, reference types, generic type parameters, and pointer types.
      - Value types
        - All numeric types, the char type, the bool type, customer struct types, and enum types
        - The content of a value type is the value. 
        - Each instance of a value-type has its own independent storage
        - The assignment of a value-type instance, always copies the instance.
        - The memory used is precisely the memory required to store the size of the field(s).
      - Reference types
        - Those which are not value types; Strings and Objects.
        - The content of a reference type is a reference to an object which contains a value.
        - The assignment of a reference type, copies the reference. *Not* the object.
        - Can be assigned the literal null, indicating that the reference does not point to an object
        - The memory used is the size of the object, the size of the reference, AND overhead (4-8Bytes of a key, 
          multithreading information, and garbage collection stuff).

  */
  internal class Types : Experiment
  {
    Types(string name)
    {
      this.name = name;
    }

    public int run()
    {
      Console.WriteLine("hello");
    }
    
    public string name {get; init;}
  }


}