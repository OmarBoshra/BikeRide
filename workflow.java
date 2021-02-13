-Task[

Ideas [

-naming conventions
-tooltips
-errors Testing and messages 
-arrows
-saved generated data for bikes .
-string reseources
=change image to image path


--finish the first use-case map then code

-check the storage tutorial
-maybe add bike picture

- ask about adding a new window

-screen binding 

-ux revise

-partial class ??
-namespace
//-window navigation
-var practice
-going to error
-check file path
-using debugger
-going back from method to xml
-getting suggestions in the binding 
-data modularization in window 
-ui resources
-
]

-App Name
Bike around.

-USER-REQUIRMENTS [
-USER-REQUIRMENTS [

-req 1 [
//sub requirments
-DATA [

-"cars"[
-id
-name
-brand

]
]

-USE-CASES [
//IF ,OR , VIEW_ 
//add VIEW_req 1 if there are many requirments/subrequirments


-usecase 1 [
//sub use cases

/*POSSIBLE-PROBLEMS*/ [

problem 1 [

actions [


]

]
]

-Tests[
//tests/subtests

]

-UI-ASSEMBLY

]

-UI-ASSEMBLY

]


-Tests[
//tests/subtests

]



]

-THEME [
//add theme requirment
//add framwork ui designs
]

]

-Employee in a bike renting company want to  manage customer orders .[

-search for customers to submit their payment.  [

-DATA[

- "_Bikes" : [
- id
- bike_type
- bike_brand
- price_perHr
- bike_details
-bike_availability
]

- "_Customers" : [
- id
- name 
- phoneNumber
- email
]

- "_Rentals" : [
- id
- date
- bike_id
- customer_id

]


]

 
-USE-CASES [
//IF ,OR , VIEW
//-VIEW "window_submittingCustomerPayment" Submitting user payment
//"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\Window_submittingcustomerPayment.drawio"
-Employee wants to search for a specific customer . [
//sub use cases
-VIEW "list_customers"  [

-VIEW "listItem_customerListItem" [

- "image_customerItemPic"
- "text_customerItemName"
- "text_customerItemPhone"

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\customerList_item.drawio"

-implementation [
//-add the _Customers dataset
-add the ui element
-connect in the code and run

tests [
one time run 

]

]

]  

-"searchbox_customerSearch"  with a default caption of CustomerName 

-"listheader_customerListHeader" 

-"comboBox_customerListFilter"   with label filterby 

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\customersList.drawio"

]

-VIEW "form_customerdetails" [

-"Header_customerHeader" with  User details.
-"Textblock_userName" 
-"Textblock_phoneNumber" 
-"Textblock_e-mail" 
-"image_customerPicture"
-"button_confirmCustomer"

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\customerDetails.drawio"
] 


-IF user clicks on the text box 
the list items automatically renders

-IF user clicks on filter combobox [

-VIEW "comboboxList_customerFilters" with Name ,phone and E-mail

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\comboboxList_customerFilters.drawio"

-user selects
the list items are filtered accordingly .

]
-user presses confirm button.
]

-Employee wants to search for a specific Bike . [
//sub use cases
-VIEW_bikelist a "_List" of bikes with a "_Searchbox"  with a default caption of BikeBrand , a "_List_header" Bikes and  a filterby "_Button"  [
"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\bikesList.drawio"

-VIEW_bikelistitem with "_ListItem"  with one  "_Text" field which is to be selected [

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\bikesList_item.drawio"

]

]

-IF user clicks on the text box 
the list items automatically renders

-IF user clicks on filter button [
-View_filterbike"_Dialog" with "_Dialogheader" filterBy , 3 "_Radiobutton" choices  Name and brand , "Type" and a confirm "_Button"

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\bikesList_filter.drawio"

]
-user presses ok 
the list items are filtered accordingly.


-VIEW_bikedetails confirmation "_form" with "_Header"  Bike details , "_Textblocks" Bike Brand and Bike Type ,Bike description ,and an "_image" user picture and "_button" confirm Bike.
"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\Bikedetails.drawio"

]

-user clicks on confirmbike button

-VIEW_Paymentdetails  [

-"_form" [

- "_formheader" Payment details.
- VIEW_bikedetails without the description
- VIEW_customerdetails.
-Total price "_textblock "
-"_Textblock" duration , hh.mm.ss
-"_numberbox" in $ format
- confirm "_Button"
]

"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\paymentdetails.drawio"


] 

]
-UI
"C:\Coding\vs-apps\BikeRide\UI\Submitting customer Payment\assembly_submittingcustomerPayment.drawio"
-search for customers to submit their deduction .

]
 
-add or remove customer


]

-THEME  [


]

]



-Outline [

-about a local small business.
[
-possible topics.
"C:\Users\hp\Documents\mobiledev\possible topics.PNG"


]
-no databases.
-using csharp.


]

-lecture 1 [


]

-lecture 2 [



]

-lecture 3 [



]

-lecture 4 [

vs
//-wpf app .net framwork
//-at the bottom the Ui exists xaml
//-size of screen is still not decided
//600 x 800
//-adding a list and filling it
//-toolbox ,common wpf controls.search  choose listbox.added outside the grid tag.,has margin attribute
//-in the properties ,name the list (list_students) ,add a prefix/id for the name.Name x ,x is refers to the windows  xmlns.
//"C:\Users\hp\Documents\srh\mobiledev\listbox.PNG"
in grid tag [
-add window title in grid "Title"
//-reveal only the code.
-load window event[
//Loaded = "Window_Loaded">creates a 'New Even Handeler'. f12 goes to definition.
//#tools > options > Colortheme
//                               > text editor > general >XAML>word wrap.
]
-inside Class MainWindow  [
-Add listbox #no usage of array. [
//List<Student> students ; 
//-hover over Students and generate class 
//"C:\Users\hp\Documents\srh\mobiledev\class creation"
//Students in new file. find it in Solution explorer.

//-inside the class Student [
]
//"C:\Users\hp\Documents\srh\mobiledev\addproperty"
//-prop + tab ,to get the set,get .
//public string nameFirst {get : set:}
//public string nameLast {get : set:}


]


- inside Window_Loaded method [ 

students = CreateStudentData (20);

-hover over it and "createmethod" with int count as input [

//private List <Student> CreateStudentDate (int count) {
//var lst = new List <Students> ());

//-create for loop for + tab [
//for (int i = 0 ; i <count ; i++){
//lst.Add (new Student {nameFirst=$"Gautam{i}" , nameLast =$"kumar{i}" })
//}

//]
//return lst;
//}
]

//list_students.ItemSource = students ;


]
//to display certain intem in the list

]


//inside list xaml add [

//DisplayMemberPath = "nameFirst".

//]
//-outside grid tag [
//<TextBlock Text = "Testing some text">


//]

-make filter[
//-added StackPanel around list xaml as a layout
[



//-add <TextBox> with textchanged event for the filter
//"C:\Users\hp\Documents\srh\mobiledev\filter"

]
-go back to the window definition.and you will find the event ,inside it [
//make sure that there is no text so this doesn't get called before the window is loaded which would produce nullpointer exception. or add if (filter == null) return;
//var filter = (sender as TextBox).Text.toLower();
//var result = from s in students where s.nameFirst.toLower().contains(filter) select s;
//list_students.ItemSource = result;


]
]
]

-lecture 5 [

//-created button to add to the list of students.

//-list of objects
//ObservableCollection <Student> students

//-inside the button  [
// var std = new Student { nameFirst = "omar " , nameLast = "ahmed" );
 
//-listbox.ScrollIntoView(std)
//-listbox.selecteditem =std;
//]

//-get rid of stackpanel height.

-create delete button and inside it [

var std = list_students.selectedItem as Student;//casts the item into its class

if (std == null)
{
MessageBox.Show ("please select student first to be deleted ", "hint");
return;

}

students.Remove(std);


]
]

-lecture 6 [
-inserting an image 
-date adding
-storing the data

-serializer to store strings 
-file stream to stream using xml serializer the information unto a certain file.
-from xml to object then deserialize it.

-to add application startup detector [
go to App.xaml
-inside Application.Resources
-startup = "" add new event handler
- check it and go to definition.
- Exit = "Application_Exit" to generate a method in the App
]
-inside the App class [
-add observable colection
public  static ObservableCollection <Student> _students // static so it can be accesed 

in Application_Exit [

My_Storage.WriteXml(App._students."Students.xml");

-generate class My_Storage and method WriteXml
inside it .

in My_Storage class [

inside WriteXml [
"D:\uni\srh\mobiledev\write.png"
Xmlserilizer //useing systemxml serialization form menu

Xmlserilizer xs =  new Xmlserilizer( typeof ObservableCollection<Student);

Filestream fs ;

fs = new Filestream (file , FileMode.Create);//append to update

xs.Serialize(fs , students);//students  is method input parameter

fs.Close();



]

]


in the debug folder it will be found .



]

in Application_startup [

_students = My_Storage.ReadXml ("Students.xml");
-create method ReadXmls

-inside ReadXml [
"D:\uni\srh\mobiledev\read.PNG"

try {

using (StreamReader sr = new StreamReader(file)){

Xmlserilizer xs = new Xmlserilizer(typeof ObservableCollection <Student>));


return ((ObservableCollection <Student>)xs.Deserialize(sr))//cast the desereialized info



}

} catch (Exception) {

throw ;

}

]



]
]

-in MainWindow in Window_Loaded assign the list_students to App._students.

-added image and binded it 


]

-lecture 7 [

-created a new window and a button navigation
-inside the new window created a new buttomn
-inside the click listener of the mainwindow  [

var win = new Win_Demo();

win.height = height
win.Title = "Demo";
win.Owner = this;
//collabsed the Window
win.Show();

-in the second window change proprtyies to center Owner[


]
-can also change the state in which its revealed.

]

-in the back button from win_demo [

- in click listener [
close();
ShowParent ();
]
private void ShowParent (){
Owner.Visibility = Visibility.Visible;
Owner.Background = Brushes.Azure;
}

private void window_closed {

ShowParent(); 

}

]


-get ride of DisplayMemberPath.
-inside list [
-create template 
<ListBox.ItemTemplate>
<DataTemplate>
<Run Text= "{Binding nameFirst}"/>
<Run Text= " "/>
<Run Text= "{Binding nameLast}"/><LineBreak/>
<DataTemplate>
<ListBox.ItemTemplate>




]
]

-lecture 8 [

-copying excel data.
-add class  item in explorer call MyConverter
-inside the class [

-keep the name space byitself
-make class public 
-create BOOLTOSTRING class as one of the classes.
[
//interface declaration its like an abstract class
public class Bool2String : IValueConverter [//generate System.Windows.Data and implement interface
-in the first method [
if((bool)value)
return "Female" ;
else
return 'Male';
]


]
// in the back method do the opposite.
-inside the xml [
<Grid.Resources>
<local:Bool2String x:Key="bool2gender"/>
<Grid.Resources>

in binded text [

Converter {StaticResource: bool2gender 
}}

]


var list- new List<string> {"imagepaths"}
list.ItemSource.list.
-xml 
"D:\uni\srh\mobiledev\gridlist"
"D:\uni\srh\mobiledev\converterimage.PNG"
]
-getting raw data

]


-lec 9 [

-notifyPropertyChanged interface.


]

lec 10 [

q[
-difference with resource dictiinary.

]
-table in resources wgich are in properties
-adding in table [

-appName in name and the name in value
-title , x
-selLanguage ,x
-languages ,x //show in the actual languages
en : English,de : Deutsch
-change access modifier to public 
- add the xmlns:globalResources="Wpf_xxx.Properties"
-in the title of the window "{x:Static globalResources:Resources.appName}"

-inside window_loaded [

-var langs = Properties.Resources.languages.Split(',');
combox.languages = langs;
//apply in combo boxes.



]

-made a copy of resources with abbreviation .hi.// for e=hindi 

-in mainwindow constructor [

var lang = "de"

Cultureinfo.CurrentCulture = new Cultureinfo(lang);
Cultureinfo.CurrentUICulture = new Cultureinfo(lang);


]
-in Settings.settings //so usr can change it iin app
-then var lang = Properties.Settings.Default.

in comboibox selectionchanged [

var lang = (sender as ComboBox).SelectedItem.ToString()/Substring(0,2);
Properties.Settings.Default.language= lang;
Properties.Settings.Default.Save();
//to restart the app.
Process.Start(Application.ResourceAssembly.Location);
App.Current.Shutdown();


]

-added flowDirection , L2R

-in window_loaded [
//chnaging the flow direction depending on language.

if(Properties.Resources.flowDirection.Contains("L2R");
FlowDirection = FlowDirection.LeftToRight;
else
FlowDirection = FlowDirection.RightToLeft;



]
] 



]

