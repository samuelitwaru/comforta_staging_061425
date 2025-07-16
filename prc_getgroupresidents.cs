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
   public class prc_getgroupresidents : GXProcedure
   {
      public prc_getgroupresidents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getgroupresidents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_ResidentPackageId ,
                           ref GXBaseCollection<SdtSDT_Resident> aP2_SDT_ResidentCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9ResidentPackageId = aP1_ResidentPackageId;
         this.AV11SDT_ResidentCollection = aP2_SDT_ResidentCollection;
         initialize();
         ExecuteImpl();
         aP2_SDT_ResidentCollection=this.AV11SDT_ResidentCollection;
      }

      public GXBaseCollection<SdtSDT_Resident> executeUdp( Guid aP0_LocationId ,
                                                           Guid aP1_ResidentPackageId )
      {
         execute(aP0_LocationId, aP1_ResidentPackageId, ref aP2_SDT_ResidentCollection);
         return AV11SDT_ResidentCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_ResidentPackageId ,
                                 ref GXBaseCollection<SdtSDT_Resident> aP2_SDT_ResidentCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9ResidentPackageId = aP1_ResidentPackageId;
         this.AV11SDT_ResidentCollection = aP2_SDT_ResidentCollection;
         SubmitImpl();
         aP2_SDT_ResidentCollection=this.AV11SDT_ResidentCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SDT_ResidentCollection = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         /* Using cursor P00H92 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9ResidentPackageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A670ResidentGroups = P00H92_A670ResidentGroups[0];
            n670ResidentGroups = P00H92_n670ResidentGroups[0];
            A29LocationId = P00H92_A29LocationId[0];
            A62ResidentId = P00H92_A62ResidentId[0];
            A11OrganisationId = P00H92_A11OrganisationId[0];
            A72ResidentSalutation = P00H92_A72ResidentSalutation[0];
            n72ResidentSalutation = P00H92_n72ResidentSalutation[0];
            A63ResidentBsnNumber = P00H92_A63ResidentBsnNumber[0];
            A73ResidentBirthDate = P00H92_A73ResidentBirthDate[0];
            A64ResidentGivenName = P00H92_A64ResidentGivenName[0];
            A65ResidentLastName = P00H92_A65ResidentLastName[0];
            A66ResidentInitials = P00H92_A66ResidentInitials[0];
            A40000ResidentImage_GXI = P00H92_A40000ResidentImage_GXI[0];
            n40000ResidentImage_GXI = P00H92_n40000ResidentImage_GXI[0];
            A68ResidentGender = P00H92_A68ResidentGender[0];
            A67ResidentEmail = P00H92_A67ResidentEmail[0];
            A70ResidentPhone = P00H92_A70ResidentPhone[0];
            A312ResidentCountry = P00H92_A312ResidentCountry[0];
            A313ResidentCity = P00H92_A313ResidentCity[0];
            A314ResidentZipCode = P00H92_A314ResidentZipCode[0];
            A315ResidentAddressLine1 = P00H92_A315ResidentAddressLine1[0];
            A316ResidentAddressLine2 = P00H92_A316ResidentAddressLine2[0];
            A96ResidentTypeId = P00H92_A96ResidentTypeId[0];
            n96ResidentTypeId = P00H92_n96ResidentTypeId[0];
            A97ResidentTypeName = P00H92_A97ResidentTypeName[0];
            A98MedicalIndicationId = P00H92_A98MedicalIndicationId[0];
            n98MedicalIndicationId = P00H92_n98MedicalIndicationId[0];
            A99MedicalIndicationName = P00H92_A99MedicalIndicationName[0];
            A599ResidentLanguage = P00H92_A599ResidentLanguage[0];
            A97ResidentTypeName = P00H92_A97ResidentTypeName[0];
            A99MedicalIndicationName = P00H92_A99MedicalIndicationName[0];
            AV10ResidentDetails = new SdtSDT_Resident(context);
            AV10ResidentDetails.gxTpr_Residentid = A62ResidentId;
            AV10ResidentDetails.gxTpr_Locationid = A29LocationId;
            AV10ResidentDetails.gxTpr_Organisationid = A11OrganisationId;
            AV10ResidentDetails.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV10ResidentDetails.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
            AV10ResidentDetails.gxTpr_Residentbirthdate = A73ResidentBirthDate;
            AV10ResidentDetails.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV10ResidentDetails.gxTpr_Residentlastname = A65ResidentLastName;
            AV10ResidentDetails.gxTpr_Residentinitials = A66ResidentInitials;
            AV10ResidentDetails.gxTpr_Residentimage = A40000ResidentImage_GXI;
            AV10ResidentDetails.gxTpr_Residentgender = A68ResidentGender;
            AV10ResidentDetails.gxTpr_Residentemail = A67ResidentEmail;
            AV10ResidentDetails.gxTpr_Residentphone = A70ResidentPhone;
            GXt_char1 = "";
            new prc_concatenateaddress(context ).execute(  A312ResidentCountry,  A313ResidentCity,  A314ResidentZipCode,  A315ResidentAddressLine1,  A316ResidentAddressLine2, out  GXt_char1) ;
            AV10ResidentDetails.gxTpr_Residentaddress = GXt_char1;
            AV10ResidentDetails.gxTpr_Residenttypeid = A96ResidentTypeId;
            AV10ResidentDetails.gxTpr_Residenttypename = A97ResidentTypeName;
            AV10ResidentDetails.gxTpr_Medicalindicationid = A98MedicalIndicationId;
            AV10ResidentDetails.gxTpr_Medicalindicationname = A99MedicalIndicationName;
            AV10ResidentDetails.gxTpr_Residentlanguage = A599ResidentLanguage;
            AV11SDT_ResidentCollection.Add(AV10ResidentDetails, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00H92_A670ResidentGroups = new string[] {""} ;
         P00H92_n670ResidentGroups = new bool[] {false} ;
         P00H92_A29LocationId = new Guid[] {Guid.Empty} ;
         P00H92_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00H92_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00H92_A72ResidentSalutation = new string[] {""} ;
         P00H92_n72ResidentSalutation = new bool[] {false} ;
         P00H92_A63ResidentBsnNumber = new string[] {""} ;
         P00H92_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P00H92_A64ResidentGivenName = new string[] {""} ;
         P00H92_A65ResidentLastName = new string[] {""} ;
         P00H92_A66ResidentInitials = new string[] {""} ;
         P00H92_A40000ResidentImage_GXI = new string[] {""} ;
         P00H92_n40000ResidentImage_GXI = new bool[] {false} ;
         P00H92_A68ResidentGender = new string[] {""} ;
         P00H92_A67ResidentEmail = new string[] {""} ;
         P00H92_A70ResidentPhone = new string[] {""} ;
         P00H92_A312ResidentCountry = new string[] {""} ;
         P00H92_A313ResidentCity = new string[] {""} ;
         P00H92_A314ResidentZipCode = new string[] {""} ;
         P00H92_A315ResidentAddressLine1 = new string[] {""} ;
         P00H92_A316ResidentAddressLine2 = new string[] {""} ;
         P00H92_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P00H92_n96ResidentTypeId = new bool[] {false} ;
         P00H92_A97ResidentTypeName = new string[] {""} ;
         P00H92_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P00H92_n98MedicalIndicationId = new bool[] {false} ;
         P00H92_A99MedicalIndicationName = new string[] {""} ;
         P00H92_A599ResidentLanguage = new string[] {""} ;
         A670ResidentGroups = "";
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
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
         AV10ResidentDetails = new SdtSDT_Resident(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getgroupresidents__default(),
            new Object[][] {
                new Object[] {
               P00H92_A670ResidentGroups, P00H92_n670ResidentGroups, P00H92_A29LocationId, P00H92_A62ResidentId, P00H92_A11OrganisationId, P00H92_A72ResidentSalutation, P00H92_n72ResidentSalutation, P00H92_A63ResidentBsnNumber, P00H92_A73ResidentBirthDate, P00H92_A64ResidentGivenName,
               P00H92_A65ResidentLastName, P00H92_A66ResidentInitials, P00H92_A40000ResidentImage_GXI, P00H92_n40000ResidentImage_GXI, P00H92_A68ResidentGender, P00H92_A67ResidentEmail, P00H92_A70ResidentPhone, P00H92_A312ResidentCountry, P00H92_A313ResidentCity, P00H92_A314ResidentZipCode,
               P00H92_A315ResidentAddressLine1, P00H92_A316ResidentAddressLine2, P00H92_A96ResidentTypeId, P00H92_n96ResidentTypeId, P00H92_A97ResidentTypeName, P00H92_A98MedicalIndicationId, P00H92_n98MedicalIndicationId, P00H92_A99MedicalIndicationName, P00H92_A599ResidentLanguage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
      private string A599ResidentLanguage ;
      private string GXt_char1 ;
      private DateTime A73ResidentBirthDate ;
      private bool n670ResidentGroups ;
      private bool n72ResidentSalutation ;
      private bool n40000ResidentImage_GXI ;
      private bool n96ResidentTypeId ;
      private bool n98MedicalIndicationId ;
      private string A670ResidentGroups ;
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
      private Guid AV8LocationId ;
      private Guid AV9ResidentPackageId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Resident> AV11SDT_ResidentCollection ;
      private GXBaseCollection<SdtSDT_Resident> aP2_SDT_ResidentCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00H92_A670ResidentGroups ;
      private bool[] P00H92_n670ResidentGroups ;
      private Guid[] P00H92_A29LocationId ;
      private Guid[] P00H92_A62ResidentId ;
      private Guid[] P00H92_A11OrganisationId ;
      private string[] P00H92_A72ResidentSalutation ;
      private bool[] P00H92_n72ResidentSalutation ;
      private string[] P00H92_A63ResidentBsnNumber ;
      private DateTime[] P00H92_A73ResidentBirthDate ;
      private string[] P00H92_A64ResidentGivenName ;
      private string[] P00H92_A65ResidentLastName ;
      private string[] P00H92_A66ResidentInitials ;
      private string[] P00H92_A40000ResidentImage_GXI ;
      private bool[] P00H92_n40000ResidentImage_GXI ;
      private string[] P00H92_A68ResidentGender ;
      private string[] P00H92_A67ResidentEmail ;
      private string[] P00H92_A70ResidentPhone ;
      private string[] P00H92_A312ResidentCountry ;
      private string[] P00H92_A313ResidentCity ;
      private string[] P00H92_A314ResidentZipCode ;
      private string[] P00H92_A315ResidentAddressLine1 ;
      private string[] P00H92_A316ResidentAddressLine2 ;
      private Guid[] P00H92_A96ResidentTypeId ;
      private bool[] P00H92_n96ResidentTypeId ;
      private string[] P00H92_A97ResidentTypeName ;
      private Guid[] P00H92_A98MedicalIndicationId ;
      private bool[] P00H92_n98MedicalIndicationId ;
      private string[] P00H92_A99MedicalIndicationName ;
      private string[] P00H92_A599ResidentLanguage ;
      private SdtSDT_Resident AV10ResidentDetails ;
   }

   public class prc_getgroupresidents__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H92;
          prmP00H92 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9ResidentPackageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H92", "SELECT T1.ResidentGroups, T1.LocationId, T1.ResidentId, T1.OrganisationId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentBirthDate, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentImage_GXI, T1.ResidentGender, T1.ResidentEmail, T1.ResidentPhone, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentTypeId, T2.ResidentTypeName, T1.MedicalIndicationId, T3.MedicalIndicationName, T1.ResidentLanguage FROM ((Trn_Resident T1 LEFT JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) LEFT JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) WHERE (T1.LocationId = :AV8LocationId) AND (POSITION(RTRIM((:AV9ResidentPackageId)) IN T1.ResidentGroups) >= 1) ORDER BY T1.LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H92,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((string[]) buf[15])[0] = rslt.getVarchar(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((string[]) buf[17])[0] = rslt.getVarchar(15);
                ((string[]) buf[18])[0] = rslt.getVarchar(16);
                ((string[]) buf[19])[0] = rslt.getVarchar(17);
                ((string[]) buf[20])[0] = rslt.getVarchar(18);
                ((string[]) buf[21])[0] = rslt.getVarchar(19);
                ((Guid[]) buf[22])[0] = rslt.getGuid(20);
                ((bool[]) buf[23])[0] = rslt.wasNull(20);
                ((string[]) buf[24])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[25])[0] = rslt.getGuid(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getVarchar(23);
                ((string[]) buf[28])[0] = rslt.getString(24, 20);
                return;
       }
    }

 }

}
