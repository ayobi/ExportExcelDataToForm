open FSharp.Data
open System
open canopy
open runner
chromeDir <- @"C:\chromedriver_win32"
start chrome
type EPMOProjects = CsvProvider< @"C:\Users\aobrien\Desktop\notes & other\CanopyWebTestingExperiment.csv">

[<EntryPoint>]
let main argv = 
    let baseUrl = "http://csbank-portal/EPMO/_layouts/15/start.aspx#"
    
    let msft = EPMOProjects.Load(@"C:\Users\aobrien\Desktop\notes & other\CanopyWebTestingExperiment.csv")

    "goto new item" &&& fun _ ->
        url (baseUrl + "/Lists/Projects/AllItems.aspx")
        for row in msft.Rows do
            click "#idHomePageNewItem"
            //"#Priority_a8eb573e-9e11-481a-a8c9-1104a54b2fbd_\24 TextField" << row.Priority 
            "#T_x002d_Shirt_x0020_Size_19fe10ce-6d1b-42a7-82da-9f3d84d7235d_\24 TextField" << row.``T-Shirt Size``
            "#Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_\24 TextField" << row.``Title or Description`` 
            "#EPMO_x0020_Team_x0020_Owner_8fb4bd13-dee4-43ff-a9d8-1024b051d2a8_\24 TextField" << row.``EPMO Team Owner``
            "#Executive_x0020_Sponser_401ea552-b584-426d-b2e6-082e551e85ab_\24 TextField" << row.``Executive Sponsor``
            "#Problem_x0020_Statement_b6ec4a6c-0d5a-4b78-8055-b9e9462e3b0e_\24 TextField" << row.``Problem Statement``
            "#Entry_x0020_Type_30a755c1-aa47-4cb7-9e11-7ac6bbfa1bc7_\24 TextField" << row.``Entry Type``
            "#Project_x0020_Driver_b26762f8-585b-4799-bcbd-e26e923f78c0_\24 TextField" << row.``Project Driver``
            "#Status_c15b34c3-ce7d-490a-b133-3f4de8801b76_\24 TextField" << row.``Task Status``
            "#StartDate_64cd368d-2f95-4bfc-a1f9-8d4324ecb007_\24 TextField" << row.``Start Date``
            "#Target_x0020_Completion_x0020_Da_fb0f3332-55fc-486a-b323-99e2337a21de_\24 TextField" << row.``Target Completion Date``
            //"#PercentComplete_d2311440-1ed6-46ea-b46d-daa643dc3886_\24 NumberField" << row.``% Complete``
            "#IT_x0020_Resources_x0020_Require_5878ea0b-51dd-4eec-b4cb-366e197971a6_\24 TextField" << row.``IT Resource Required``
            "#Internal_x0020_Resources_x0020_R_45209308-aaa7-4b7c-aa31-01fb2ed33984_\24 TextField" << row.``Internal Resources Required``
            "#Capital_x0020_Outlay_x0020_Y_x00_2d59de8e-d0ec-46c2-a9de-ae1b3e39438e_\24 TextField" << row.``Capital Outlay``
            "#Budgeted_x0020_Costs_5194491f-1e35-45cc-8a89-e31005596646_\24 TextField" << row.``Budgeted Costs``
            "#ROI_ca1cf96b-9f4b-416c-a163-174d87c81325_\24 TextField" << row.ROI
            click "#ctl00_ctl26_g_f41678e9_3392_40e4_b9be_945ebfd050ee_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem"
 

    //run all tests
    run()

    printfn "press [enter] to exit"
    System.Console.ReadLine() |> ignore

    quit()


    0

