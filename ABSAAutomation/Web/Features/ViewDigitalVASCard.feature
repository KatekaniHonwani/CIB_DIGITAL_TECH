Feature:   View digital VAS card

@R1.1
Scenario Outline: Verify that a Member can View Value Added Services Benefits

  Given a member is on the SSP login page
  When a member logs in to SSP using "<emailAddress>"
  
  And Navigates to Value Added Services
  Then the member is presented with a list of all the services available to them depending on whether they "<haveFuneralBenefits>" or not

    | vasHeading                          | vasDescription                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |  
    | 24-Hour Health Information Helpline | Provides you with easy access to medical resources, such as general medical information, lifestyle advice and explanations and interpretations of medical terminology.                                                                                                                                                                                                                                                                                                                                                          |
    | Emergency Ambulance Assistance      | In the case of a medical emergency, you can call the 24-Hour Contact Centre where you will be assisted by trained medical personnel, who can provide guidance through a medical crisis situation. For life-threatening medical crisis, an appropriate road and/or air response will be dispatched.                                                                                                                                                                                                                              |
    | R5 000 Hospital Admission Guarantee | Should you or your immediate family be admitted into hospital, and a hospital guarantee cash payment is required, the 24-Hour Contact Centre can be contacted to cover up to R5 000 (including VAT) of this required payment.                                                                                                                                                                                                                                                                                                   |
    | Legal Assist Helpline               | By contacting the 24-Hour Contact Centre, you can access professional assistance from a panel of qualified lawyers/ attorneys, who will assess the situation, explain your rights and advise you of the best course of action to take.                                                                                                                                                                                                                                                                                          |
    | Trauma Counselling                  | Offers you and your immediate family access to trauma counselling, to assist with emotional recovery following a critical incident.                                                                                                                                                                                                                                                                                                                                                                                             |
    | Funeral Assistance Service          | A 24-hour service that will assist you and/or your bereaved family members with funeral arrangements and transportation of the deceased to where the funeral will be taking place, provided that the destination is more than 100 km's away from where the deceased's body is being kept. The territories for transportation of the deceased include anywhere within South Africa, Namibia, Mozambique, Botswana, Lesotho, eSwatini and Zimbabwe. Embalming and refrigerated transportation is not part of the service offered. |

  And contact details are displayed

    | Field            | Value                                                                                                                                                    |
    | telephonicAccess | JD 24-Hour Contact Centre (telephonic access) If calling from within South Africa: +27 11 966 5011 If calling from outside of South Africa: 0861 724 247 |
    | digitalMessaging | JD 24-Hour Contact Centre (digital messaging access) Digital messaging platform: AccessVAS.liberty.co.za QR code:                                        |
  
  And a member can download the contact details
  When a member clicks on the digital messaging platform link
  Then They are redirected to the access vas page on a new tab.

    
Examples:

  | emailAddress     | haveFuneralBenefits |
  | member9@test.com | true                |
