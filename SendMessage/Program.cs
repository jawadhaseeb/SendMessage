using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace SendMessage
{
    class Program
    {
        static void Main ( string[] args )
        {
            //creating object of program class to access methods    
            Program obj = new Program ();
            Console.WriteLine ("Please Enter Input values..");
              
            obj.InvokeService ();
        }
        public HttpWebRequest CreateSOAPWebRequest ( )
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create (@"https://extdev.lexisgateway.co.za/KGProxyEstateAgent/messaging.asmx");
            //SOAPAction    
            Req.Headers.Add (@"SOAPAction:http://www.korbitec.com/SendMessage");
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }
        public void InvokeService ( )
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest ();

            XmlDocument SOAPReqBody = new XmlDocument ();
            //SOAP Body Request    
            SOAPReqBody.LoadXml (@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <SendMessage xmlns=""http://www.korbitec.com/"">
<message xmlns=""http://schemas.korbitecgateway.co.za/message.xsd"">
        <GeneratorApplication>BankApp</GeneratorApplication>
        <GeneratorVersion>-</GeneratorVersion>
        <MatterKref>4cc0a874-d87f-41b8-97ce-e4ba8e6c1539</MatterKref>
        <SenderKref>afa66508-71e5-45df-9746-031dc1758aa0</SenderKref>
        <SenderRef>testref</SenderRef>
        <SenderKeyIdentifier></SenderKeyIdentifier>
        <RecipientKref>73af5380-79e1-487c-abcd-2c95a20287fc</RecipientKref>
        <RecipientRef></RecipientRef>
        <RecipientKeyIdentifier></RecipientKeyIdentifier>
        <Institution>TestInstitution</Institution>
        <Instruction>transferRegistration</Instruction>
        <Type>initialInstruction</Type>
        <DateCreated>2011-03-31T17:23:35.3932804+02:00</DateCreated>
        <DateActioned>2011-03-31T17:23:35.3932804+02:00</DateActioned>
        <Body xmlns = ""https://korbitecgateway.korbitec.com/schemas/transfer/initialInstruction_1.1.xsd
"" branchName=""Sea Point"" contactName=""Susan Smith""> <Data>
 <Transfer>
 <PurchasePrice> 750000 </PurchasePrice>
 <DateOfSale> 2008-04-12T12:00:00Z </DateOfSale>
 <DateOfTransfer> 2008-07-01T12:00:00Z </DateOfTransfer>
 <DepositAmount> 10000.00 </DepositAmount>
 <DepositDue> 2008-04-12T12:00:00Z </DepositDue>
 <AdditionalInstructions> Microsoft's new Windows ad made its
 debut during the Grammy Awards on Sunday.It stars a
 4-year-old cutie named Kylie (Silverlight required) showing
 how easy it is to use Windows Live Photo Gallery to edit
 and share photos.And while it's impressive that little
 Kylie is able to transfer a snapshot of her pet fish from
 her camera to a PC, color-correct it, and e-mail it to her
   family, what's truly amazing is that the toddler was also
 apparently able to read, understand, and accept Windows
 Live's Terms of Use and Privacy Policy. (But minors can't
 legally execute contracts, can
 they ?)</AdditionalInstructions>
 
  <AgencyDetails>
 
  <Name> Pam Golding </Name>
    
     <Branch> Sea Point </Branch>
       
        <Contact> Susan Smith </Contact>
          
           <Reference> PG562998 </Reference>
          
           <Email> rudiv@korbitec.com </Email>
             
              <PhoneNumber> 0836549874 </PhoneNumber>
             
              <FaxNumber> 0214454569 </FaxNumber>
             
              <PhysicalAddress/>
             
              <PostalAddress/>
             
              </AgencyDetails>
             
              <Parties>
             
              <Individuals>
             
              <Individual>
             
              <Role> Purchasers Spouse </Role>
                
                 <FullName> Mary Bloggs </FullName>
                   
                    <Title> Mrs </Title>
                   
                    <Initials> M </Initials>
                   
                    <LastName> Bloggs </LastName>
                   
                    <FirstNames> Mary </FirstNames>
                   
                    <PostalAddress> PO 36789 Newlands 7890 </PostalAddress>
                      
                       <ResidentialAddress/>
                      
                       <HomePhone> 0214569874 </HomePhone>
                      
                       <WorkPhone/>
                      
                       <CellPhone> 0836541235 </CellPhone>
                      
                       <IDType> Identity Document </IDType>
                         
                          <IDNumber> 7512235056089 </IDNumber>
                         
                          <IncomeTaxNumber> SAR235476457 / 7 </IncomeTaxNumber>
                         
                          <MaritalStatus> ANC </MaritalStatus>
                         
                          <PermanentRes> 0 </PermanentRes>
                         
                          <Email> Mary@email.address.com </Email>
                            
                             </Individual>
                            
                             </Individuals>
                            
                             </Parties>
                            
                             <PropertyCollection>
                            
                             <Properties>
                            
                             <Property>
                            
                             <PropertyType> Sectional </PropertyType>
                            
                             <ErfNumber/>
                            
                             <PropertyDescription> Unit 21 SS High Cap Three,
                                Situated at Vredehoek</PropertyDescription>
                               
                                <StreetAddress> 3a Upland Avenue, Devils Peak,
 8000 </StreetAddress>
 <Extent> 105 </Extent>
 <ExtentUnits> Square Metres </ExtentUnits>
   
    <SectionalTitleDetails>
   
    <SectionTitleUnitNumber> 21 </SectionTitleUnitNumber>
   
    <ComplexName> SS HIGH CAPE THREE </ComplexName>
      
       <ExclusiveUseAreas>
      
       <EUA>
      
       <Description> Describe this </Description>
         
          <Extent> 208 </Extent>
         
          <ExtentUnits> Square Metres </ExtentUnits>
            
             <HeldUnder/>
            
             </EUA>
            
             </ExclusiveUseAreas>
            
             </SectionalTitleDetails>
            
             </Property>
            
             </Properties>
            
             </PropertyCollection>
            
             <ExistingBonds>
            
             <ExistingBond>
            
             <BondHolder> ABSA </BondHolder>
            
             <Branch> Sea Point </Branch>
               
                <AccountNumber> 34634673547001 </AccountNumber>
               
                </ExistingBond>
               
                </ExistingBonds>
               
                <NewBond>
               
                <Channel> Some Random Channel String </Channel>
                  
                   <ContactName> Some Random Contact Name String
 thingy </ContactName>
 <ContactNumber> 1234567890 </ContactNumber>
 <BondGrantDate> 2008-04-12T12:00:00Z </BondGrantDate>
        
         <BondAttorneyName> Some Random Bond Attorney Name String
 thingy </BondAttorneyName>
 <BondAttorneyPhoneNumber> 1234567890 </BondAttorneyPhoneNumber>
 </NewBond>
 <TransferringAttorney>
 <Name> Bisset Boemke Macblain</Name>
   
    <PhoneNumber> 0214569874 </PhoneNumber>
   
    </TransferringAttorney>
   
    </Transfer>
   
    </Data></Body>
      </message>
             
 

   
               </SendMessage>
              </soap:Body>  
            </soap:Envelope>");
            using ( Stream stream = request.GetRequestStream () )
            {
                SOAPReqBody.Save (stream);
            }
            //Geting response from request    
            using ( WebResponse Serviceres = request.GetResponse () )
            {
                //XmlNode elem = Serviceres;

                using ( StreamReader rd = new StreamReader (Serviceres.GetResponseStream ()) )
                {

                    //reading stream    
                    var ServiceResult = rd.ReadToEnd ();
                    var asdac = XDocument.Parse (ServiceResult);

                    var query = from c in asdac.Root.Attributes () select c.Value;
                    //.Descendants ("AttorneyItem")
                    //where c.Attribute ("Kref") !=null
                    //select c.Element ("Name").Value+" " +
                    //       c.Element ("Region").Value;

                    Console.WriteLine (query);
                    Console.WriteLine (ServiceResult);

                    var xmarterid = asdac.Root.Descendants ().Where (d => d.Name.LocalName.Equals ("Nme")).ToList ();
                    //Console.WriteLine (xmarterid[0].Name);
                    var xd = ServiceResult.ToString ();
                    Console.WriteLine (xd);
                    Console.WriteLine (ServiceResult);
                    Console.WriteLine (asdac);
                    Console.ReadLine ();
                }
            }
        }
    }
}
