using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_getresidentinformation : GXProcedure
   {
      public prc_getresidentinformation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getresidentinformation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_userId ,
                           out string aP1_response )
      {
         this.AV10userId = aP0_userId;
         this.AV9response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV9response;
      }

      public string executeUdp( string aP0_userId )
      {
         execute(aP0_userId, out aP1_response);
         return AV9response ;
      }

      public void executeSubmit( string aP0_userId ,
                                 out string aP1_response )
      {
         this.AV10userId = aP0_userId;
         this.AV9response = "" ;
         SubmitImpl();
         aP1_response=this.AV9response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GXLvl1 = 0;
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {AV10userId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P00752_A71ResidentGUID[0];
            A29LocationId = P00752_A29LocationId[0];
            A11OrganisationId = P00752_A11OrganisationId[0];
            A72ResidentSalutation = P00752_A72ResidentSalutation[0];
            A63ResidentBsnNumber = P00752_A63ResidentBsnNumber[0];
            A73ResidentBirthDate = P00752_A73ResidentBirthDate[0];
            A64ResidentGivenName = P00752_A64ResidentGivenName[0];
            A65ResidentLastName = P00752_A65ResidentLastName[0];
            A66ResidentInitials = P00752_A66ResidentInitials[0];
            A40000ResidentImage_GXI = P00752_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = P00752_n40000ResidentImage_GXI[0];
            A68ResidentGender = P00752_A68ResidentGender[0];
            A67ResidentEmail = P00752_A67ResidentEmail[0];
            A70ResidentPhone = P00752_A70ResidentPhone[0];
            A312ResidentCountry = P00752_A312ResidentCountry[0];
            A313ResidentCity = P00752_A313ResidentCity[0];
            A314ResidentZipCode = P00752_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = P00752_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = P00752_A316ResidentAddressLine2[0];
            A96ResidentTypeId = P00752_A96ResidentTypeId[0];
            n96ResidentTypeId = P00752_n96ResidentTypeId[0];
            A97ResidentTypeName = P00752_A97ResidentTypeName[0];
            A98MedicalIndicationId = P00752_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P00752_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P00752_A99MedicalIndicationName[0];
            A599ResidentLanguage = P00752_A599ResidentLanguage[0];
            A62ResidentId = P00752_A62ResidentId[0];
            A97ResidentTypeName = P00752_A97ResidentTypeName[0];
            A99MedicalIndicationName = P00752_A99MedicalIndicationName[0];
            AV13GXLvl1 = 1;
            AV8ResidentDetails.gxTpr_Residentid = StringUtil.StrToGuid( A71ResidentGUID);
            AV8ResidentDetails.gxTpr_Locationid = A29LocationId;
            AV8ResidentDetails.gxTpr_Organisationid = A11OrganisationId;
            AV8ResidentDetails.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV8ResidentDetails.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
            AV8ResidentDetails.gxTpr_Residentbirthdate = A73ResidentBirthDate;
            AV8ResidentDetails.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV8ResidentDetails.gxTpr_Residentlastname = A65ResidentLastName;
            AV8ResidentDetails.gxTpr_Residentinitials = A66ResidentInitials;
            AV8ResidentDetails.gxTpr_Residentimage = A40000ResidentImage_GXI;
            AV8ResidentDetails.gxTpr_Residentgender = A68ResidentGender;
            AV8ResidentDetails.gxTpr_Residentemail = A67ResidentEmail;
            AV8ResidentDetails.gxTpr_Residentphone = A70ResidentPhone;
            GXt_char1 = "";
            new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char1) ;
            AV8ResidentDetails.gxTpr_Residentaddress = GXt_char1;
            AV8ResidentDetails.gxTpr_Residenttypeid = A96ResidentTypeId;
            AV8ResidentDetails.gxTpr_Residenttypename = A97ResidentTypeName;
            AV8ResidentDetails.gxTpr_Medicalindicationid = A98MedicalIndicationId;
            AV8ResidentDetails.gxTpr_Medicalindicationname = A99MedicalIndicationName;
            AV12GAMUser.load( A71ResidentGUID);
            AV8ResidentDetails.gxTpr_Residentlanguage = A599ResidentLanguage;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            AV11isNotFound = true;
         }
         if ( AV11isNotFound )
         {
            AV9response = context.GetMessage( "No resident record found!", "");
         }
         else
         {
            AV9response = AV8ResidentDetails.ToJSonString(false, true);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9response = "";
         P00752_A71ResidentGUID = new string[] {""} ;
         P00752_A29LocationId = new Guid[] {Guid.Empty} ;
         P00752_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00752_A72ResidentSalutation = new string[] {""} ;
         P00752_A63ResidentBsnNumber = new string[] {""} ;
         P00752_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P00752_A64ResidentGivenName = new string[] {""} ;
         P00752_A65ResidentLastName = new string[] {""} ;
         P00752_A66ResidentInitials = new string[] {""} ;
         P00752_A40000ResidentImage_GXI = new string[] {""} ;
         P00752_n40000ResidentImage_GXI = new bool[] {false} ;
         P00752_A68ResidentGender = new string[] {""} ;
         P00752_A67ResidentEmail = new string[] {""} ;
         P00752_A70ResidentPhone = new string[] {""} ;
         P00752_A312ResidentCountry = new string[] {""} ;
         P00752_A313ResidentCity = new string[] {""} ;
         P00752_A314ResidentZipCode = new string[] {""} ;
         P00752_A315ResidentAddressLine1 = new string[] {""} ;
         P00752_A316ResidentAddressLine2 = new string[] {""} ;
         P00752_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P00752_n96ResidentTypeId = new bool[] {false} ;
         P00752_A97ResidentTypeName = new string[] {""} ;
         P00752_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P00752_n98MedicalIndicationId = new bool[] {false} ;
         P00752_A99MedicalIndicationName = new string[] {""} ;
         P00752_A599ResidentLanguage = new string[] {""} ;
         P00752_A62ResidentId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A40000ResidentImage_GXI = "";
         A68ResidentGender = "";
         A67ResidentEmail = "";
         A70ResidentPhone = "";
         A312ResidentCountry = "";
         A313ResidentCity = "";
         A314ResidentZipCode = "";
         A315ResidentAddressLine1 = "";
         A316ResidentAddressLine2 = "";
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A599ResidentLanguage = "";
         A62ResidentId = Guid.Empty;
         AV8ResidentDetails = new SdtSDT_Resident(context);
         GXt_char1 = "";
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getresidentinformation__default(),
            new Object[][] {
                new Object[] {
               P00752_A71ResidentGUID, P00752_A29LocationId, P00752_A11OrganisationId, P00752_A72ResidentSalutation, P00752_A63ResidentBsnNumber, P00752_A73ResidentBirthDate, P00752_A64ResidentGivenName, P00752_A65ResidentLastName, P00752_A66ResidentInitials, P00752_A40000ResidentImage_GXI,
               P00752_n40000ResidentImage_GXI, P00752_A68ResidentGender, P00752_A67ResidentEmail, P00752_A70ResidentPhone, P00752_A312ResidentCountry, P00752_A313ResidentCity, P00752_A314ResidentZipCode, P00752_A315ResidentAddressLine1, P00752_A316ResidentAddressLine2, P00752_A96ResidentTypeId,
               P00752_n96ResidentTypeId, P00752_A97ResidentTypeName, P00752_A98MedicalIndicationId, P00752_n98MedicalIndicationId, P00752_A99MedicalIndicationName, P00752_A599ResidentLanguage, P00752_A62ResidentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl1 ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string A599ResidentLanguage ;
      private string GXt_char1 ;
      private DateTime A73ResidentBirthDate ;
      private bool n40000ResidentImage_GXI ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private bool AV11isNotFound ;
      private string AV9response ;
      private string AV10userId ;
      private string A71ResidentGUID ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A40000ResidentImage_GXI ;
      private string A68ResidentGender ;
      private string A67ResidentEmail ;
      private string A312ResidentCountry ;
      private string A313ResidentCity ;
      private string A314ResidentZipCode ;
      private string A315ResidentAddressLine1 ;
      private string A316ResidentAddressLine2 ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00752_A71ResidentGUID ;
      private Guid[] P00752_A29LocationId ;
      private Guid[] P00752_A11OrganisationId ;
      private string[] P00752_A72ResidentSalutation ;
      private string[] P00752_A63ResidentBsnNumber ;
      private DateTime[] P00752_A73ResidentBirthDate ;
      private string[] P00752_A64ResidentGivenName ;
      private string[] P00752_A65ResidentLastName ;
      private string[] P00752_A66ResidentInitials ;
      private string[] P00752_A40000ResidentImage_GXI ;
      private bool[] P00752_n40000ResidentImage_GXI ;
      private string[] P00752_A68ResidentGender ;
      private string[] P00752_A67ResidentEmail ;
      private string[] P00752_A70ResidentPhone ;
      private string[] P00752_A312ResidentCountry ;
      private string[] P00752_A313ResidentCity ;
      private string[] P00752_A314ResidentZipCode ;
      private string[] P00752_A315ResidentAddressLine1 ;
      private string[] P00752_A316ResidentAddressLine2 ;
      private Guid[] P00752_A96ResidentTypeId ;
      private bool[] P00752_n96ResidentTypeId ;
      private string[] P00752_A97ResidentTypeName ;
      private Guid[] P00752_A98MedicalIndicationId ;
      private bool[] P00752_n98MedicalIndicationId ;
      private string[] P00752_A99MedicalIndicationName ;
      private string[] P00752_A599ResidentLanguage ;
      private Guid[] P00752_A62ResidentId ;
      private SdtSDT_Resident AV8ResidentDetails ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
      private string aP1_response ;
   }

   public class prc_getresidentinformation__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("AV10userId",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "SELECT T1.ResidentGUID, T1.LocationId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentBirthDate, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentImage_GXI, T1.ResidentGender, T1.ResidentEmail, T1.ResidentPhone, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentLanguage, T1.ResidentId FROM ((Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) WHERE T1.ResidentGUID = ( :AV10userId) ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((Guid[]) buf[19])[0] = rslt.getGuid(19);
                ((bool[]) buf[20])[0] = rslt.wasNull(19);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((Guid[]) buf[22])[0] = rslt.getGuid(21);
                ((bool[]) buf[23])[0] = rslt.wasNull(21);
                ((string[]) buf[24])[0] = rslt.getVarchar(22);
                ((string[]) buf[25])[0] = rslt.getString(23, 20);
                ((Guid[]) buf[26])[0] = rslt.getGuid(24);
                return;
       }
    }

 }

}
