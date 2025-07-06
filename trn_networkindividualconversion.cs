using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_networkindividualconversion : GXProcedure
   {
      public trn_networkindividualconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_networkindividualconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_NETWOR2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A495NetworkIndividualRelationship = TRN_NETWOR2_A495NetworkIndividualRelationship[0];
            A435NetworkIndividualHomePhoneNumb = TRN_NETWOR2_A435NetworkIndividualHomePhoneNumb[0];
            A434NetworkIndividualHomePhoneCode = TRN_NETWOR2_A434NetworkIndividualHomePhoneCode[0];
            A433NetworkIndividualHomePhone = TRN_NETWOR2_A433NetworkIndividualHomePhone[0];
            A360NetworkIndividualPhoneNumber = TRN_NETWOR2_A360NetworkIndividualPhoneNumber[0];
            A359NetworkIndividualPhoneCode = TRN_NETWOR2_A359NetworkIndividualPhoneCode[0];
            A326NetworkIndividualAddressLine2 = TRN_NETWOR2_A326NetworkIndividualAddressLine2[0];
            A325NetworkIndividualAddressLine1 = TRN_NETWOR2_A325NetworkIndividualAddressLine1[0];
            A324NetworkIndividualZipCode = TRN_NETWOR2_A324NetworkIndividualZipCode[0];
            A323NetworkIndividualCity = TRN_NETWOR2_A323NetworkIndividualCity[0];
            A322NetworkIndividualCountry = TRN_NETWOR2_A322NetworkIndividualCountry[0];
            A81NetworkIndividualGender = TRN_NETWOR2_A81NetworkIndividualGender[0];
            A79NetworkIndividualPhone = TRN_NETWOR2_A79NetworkIndividualPhone[0];
            A78NetworkIndividualEmail = TRN_NETWOR2_A78NetworkIndividualEmail[0];
            A77NetworkIndividualLastName = TRN_NETWOR2_A77NetworkIndividualLastName[0];
            A76NetworkIndividualGivenName = TRN_NETWOR2_A76NetworkIndividualGivenName[0];
            A75NetworkIndividualBsnNumber = TRN_NETWOR2_A75NetworkIndividualBsnNumber[0];
            A74NetworkIndividualId = TRN_NETWOR2_A74NetworkIndividualId[0];
            /*
               INSERT RECORD ON TABLE GXA0017

            */
            AV2NetworkIndividualId = A74NetworkIndividualId;
            AV3NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            AV4NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            AV5NetworkIndividualLastName = A77NetworkIndividualLastName;
            AV6NetworkIndividualEmail = A78NetworkIndividualEmail;
            AV7NetworkIndividualPhone = A79NetworkIndividualPhone;
            AV8NetworkIndividualGender = A81NetworkIndividualGender;
            AV9NetworkIndividualCountry = A322NetworkIndividualCountry;
            AV10NetworkIndividualCity = A323NetworkIndividualCity;
            AV11NetworkIndividualZipCode = A324NetworkIndividualZipCode;
            AV12NetworkIndividualAddressLine1 = A325NetworkIndividualAddressLine1;
            AV13NetworkIndividualAddressLine2 = A326NetworkIndividualAddressLine2;
            AV14NetworkIndividualPhoneCode = A359NetworkIndividualPhoneCode;
            AV15NetworkIndividualPhoneNumber = A360NetworkIndividualPhoneNumber;
            AV16NetworkIndividualHomePhone = A433NetworkIndividualHomePhone;
            AV17NetworkIndividualHomePhoneCode = A434NetworkIndividualHomePhoneCode;
            AV18NetworkIndividualHomePhoneNumb = A435NetworkIndividualHomePhoneNumb;
            AV19NetworkIndividualRelationship = A495NetworkIndividualRelationship;
            AV20NetworkIndividualSalutation = "";
            nV20NetworkIndividualSalutation = false;
            nV20NetworkIndividualSalutation = true;
            AV21ResidentId = Guid.Empty;
            /* Using cursor TRN_NETWOR3 */
            pr_default.execute(1, new Object[] {AV2NetworkIndividualId, AV3NetworkIndividualBsnNumber, AV4NetworkIndividualGivenName, AV5NetworkIndividualLastName, AV6NetworkIndividualEmail, AV7NetworkIndividualPhone, AV8NetworkIndividualGender, AV9NetworkIndividualCountry, AV10NetworkIndividualCity, AV11NetworkIndividualZipCode, AV12NetworkIndividualAddressLine1, AV13NetworkIndividualAddressLine2, AV14NetworkIndividualPhoneCode, AV15NetworkIndividualPhoneNumber, AV16NetworkIndividualHomePhone, AV17NetworkIndividualHomePhoneCode, AV18NetworkIndividualHomePhoneNumb, AV19NetworkIndividualRelationship, nV20NetworkIndividualSalutation, AV20NetworkIndividualSalutation, AV21ResidentId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0017");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TRN_NETWOR2_A495NetworkIndividualRelationship = new string[] {""} ;
         TRN_NETWOR2_A435NetworkIndividualHomePhoneNumb = new string[] {""} ;
         TRN_NETWOR2_A434NetworkIndividualHomePhoneCode = new string[] {""} ;
         TRN_NETWOR2_A433NetworkIndividualHomePhone = new string[] {""} ;
         TRN_NETWOR2_A360NetworkIndividualPhoneNumber = new string[] {""} ;
         TRN_NETWOR2_A359NetworkIndividualPhoneCode = new string[] {""} ;
         TRN_NETWOR2_A326NetworkIndividualAddressLine2 = new string[] {""} ;
         TRN_NETWOR2_A325NetworkIndividualAddressLine1 = new string[] {""} ;
         TRN_NETWOR2_A324NetworkIndividualZipCode = new string[] {""} ;
         TRN_NETWOR2_A323NetworkIndividualCity = new string[] {""} ;
         TRN_NETWOR2_A322NetworkIndividualCountry = new string[] {""} ;
         TRN_NETWOR2_A81NetworkIndividualGender = new string[] {""} ;
         TRN_NETWOR2_A79NetworkIndividualPhone = new string[] {""} ;
         TRN_NETWOR2_A78NetworkIndividualEmail = new string[] {""} ;
         TRN_NETWOR2_A77NetworkIndividualLastName = new string[] {""} ;
         TRN_NETWOR2_A76NetworkIndividualGivenName = new string[] {""} ;
         TRN_NETWOR2_A75NetworkIndividualBsnNumber = new string[] {""} ;
         TRN_NETWOR2_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         A495NetworkIndividualRelationship = "";
         A435NetworkIndividualHomePhoneNumb = "";
         A434NetworkIndividualHomePhoneCode = "";
         A433NetworkIndividualHomePhone = "";
         A360NetworkIndividualPhoneNumber = "";
         A359NetworkIndividualPhoneCode = "";
         A326NetworkIndividualAddressLine2 = "";
         A325NetworkIndividualAddressLine1 = "";
         A324NetworkIndividualZipCode = "";
         A323NetworkIndividualCity = "";
         A322NetworkIndividualCountry = "";
         A81NetworkIndividualGender = "";
         A79NetworkIndividualPhone = "";
         A78NetworkIndividualEmail = "";
         A77NetworkIndividualLastName = "";
         A76NetworkIndividualGivenName = "";
         A75NetworkIndividualBsnNumber = "";
         A74NetworkIndividualId = Guid.Empty;
         AV2NetworkIndividualId = Guid.Empty;
         AV3NetworkIndividualBsnNumber = "";
         AV4NetworkIndividualGivenName = "";
         AV5NetworkIndividualLastName = "";
         AV6NetworkIndividualEmail = "";
         AV7NetworkIndividualPhone = "";
         AV8NetworkIndividualGender = "";
         AV9NetworkIndividualCountry = "";
         AV10NetworkIndividualCity = "";
         AV11NetworkIndividualZipCode = "";
         AV12NetworkIndividualAddressLine1 = "";
         AV13NetworkIndividualAddressLine2 = "";
         AV14NetworkIndividualPhoneCode = "";
         AV15NetworkIndividualPhoneNumber = "";
         AV16NetworkIndividualHomePhone = "";
         AV17NetworkIndividualHomePhoneCode = "";
         AV18NetworkIndividualHomePhoneNumb = "";
         AV19NetworkIndividualRelationship = "";
         AV20NetworkIndividualSalutation = "";
         AV21ResidentId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividualconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_NETWOR2_A495NetworkIndividualRelationship, TRN_NETWOR2_A435NetworkIndividualHomePhoneNumb, TRN_NETWOR2_A434NetworkIndividualHomePhoneCode, TRN_NETWOR2_A433NetworkIndividualHomePhone, TRN_NETWOR2_A360NetworkIndividualPhoneNumber, TRN_NETWOR2_A359NetworkIndividualPhoneCode, TRN_NETWOR2_A326NetworkIndividualAddressLine2, TRN_NETWOR2_A325NetworkIndividualAddressLine1, TRN_NETWOR2_A324NetworkIndividualZipCode, TRN_NETWOR2_A323NetworkIndividualCity,
               TRN_NETWOR2_A322NetworkIndividualCountry, TRN_NETWOR2_A81NetworkIndividualGender, TRN_NETWOR2_A79NetworkIndividualPhone, TRN_NETWOR2_A78NetworkIndividualEmail, TRN_NETWOR2_A77NetworkIndividualLastName, TRN_NETWOR2_A76NetworkIndividualGivenName, TRN_NETWOR2_A75NetworkIndividualBsnNumber, TRN_NETWOR2_A74NetworkIndividualId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0017 ;
      private string A433NetworkIndividualHomePhone ;
      private string A79NetworkIndividualPhone ;
      private string AV7NetworkIndividualPhone ;
      private string AV16NetworkIndividualHomePhone ;
      private string AV20NetworkIndividualSalutation ;
      private string Gx_emsg ;
      private bool nV20NetworkIndividualSalutation ;
      private string A495NetworkIndividualRelationship ;
      private string A435NetworkIndividualHomePhoneNumb ;
      private string A434NetworkIndividualHomePhoneCode ;
      private string A360NetworkIndividualPhoneNumber ;
      private string A359NetworkIndividualPhoneCode ;
      private string A326NetworkIndividualAddressLine2 ;
      private string A325NetworkIndividualAddressLine1 ;
      private string A324NetworkIndividualZipCode ;
      private string A323NetworkIndividualCity ;
      private string A322NetworkIndividualCountry ;
      private string A81NetworkIndividualGender ;
      private string A78NetworkIndividualEmail ;
      private string A77NetworkIndividualLastName ;
      private string A76NetworkIndividualGivenName ;
      private string A75NetworkIndividualBsnNumber ;
      private string AV3NetworkIndividualBsnNumber ;
      private string AV4NetworkIndividualGivenName ;
      private string AV5NetworkIndividualLastName ;
      private string AV6NetworkIndividualEmail ;
      private string AV8NetworkIndividualGender ;
      private string AV9NetworkIndividualCountry ;
      private string AV10NetworkIndividualCity ;
      private string AV11NetworkIndividualZipCode ;
      private string AV12NetworkIndividualAddressLine1 ;
      private string AV13NetworkIndividualAddressLine2 ;
      private string AV14NetworkIndividualPhoneCode ;
      private string AV15NetworkIndividualPhoneNumber ;
      private string AV17NetworkIndividualHomePhoneCode ;
      private string AV18NetworkIndividualHomePhoneNumb ;
      private string AV19NetworkIndividualRelationship ;
      private Guid A74NetworkIndividualId ;
      private Guid AV2NetworkIndividualId ;
      private Guid AV21ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TRN_NETWOR2_A495NetworkIndividualRelationship ;
      private string[] TRN_NETWOR2_A435NetworkIndividualHomePhoneNumb ;
      private string[] TRN_NETWOR2_A434NetworkIndividualHomePhoneCode ;
      private string[] TRN_NETWOR2_A433NetworkIndividualHomePhone ;
      private string[] TRN_NETWOR2_A360NetworkIndividualPhoneNumber ;
      private string[] TRN_NETWOR2_A359NetworkIndividualPhoneCode ;
      private string[] TRN_NETWOR2_A326NetworkIndividualAddressLine2 ;
      private string[] TRN_NETWOR2_A325NetworkIndividualAddressLine1 ;
      private string[] TRN_NETWOR2_A324NetworkIndividualZipCode ;
      private string[] TRN_NETWOR2_A323NetworkIndividualCity ;
      private string[] TRN_NETWOR2_A322NetworkIndividualCountry ;
      private string[] TRN_NETWOR2_A81NetworkIndividualGender ;
      private string[] TRN_NETWOR2_A79NetworkIndividualPhone ;
      private string[] TRN_NETWOR2_A78NetworkIndividualEmail ;
      private string[] TRN_NETWOR2_A77NetworkIndividualLastName ;
      private string[] TRN_NETWOR2_A76NetworkIndividualGivenName ;
      private string[] TRN_NETWOR2_A75NetworkIndividualBsnNumber ;
      private Guid[] TRN_NETWOR2_A74NetworkIndividualId ;
   }

   public class trn_networkindividualconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_NETWOR2;
          prmTRN_NETWOR2 = new Object[] {
          };
          Object[] prmTRN_NETWOR3;
          prmTRN_NETWOR3 = new Object[] {
          new ParDef("AV2NetworkIndividualId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3NetworkIndividualBsnNumber",GXType.VarChar,9,0) ,
          new ParDef("AV4NetworkIndividualGivenName",GXType.VarChar,100,0) ,
          new ParDef("AV5NetworkIndividualLastName",GXType.VarChar,100,0) ,
          new ParDef("AV6NetworkIndividualEmail",GXType.VarChar,100,0) ,
          new ParDef("AV7NetworkIndividualPhone",GXType.Char,20,0) ,
          new ParDef("AV8NetworkIndividualGender",GXType.VarChar,40,0) ,
          new ParDef("AV9NetworkIndividualCountry",GXType.VarChar,100,0) ,
          new ParDef("AV10NetworkIndividualCity",GXType.VarChar,100,0) ,
          new ParDef("AV11NetworkIndividualZipCode",GXType.VarChar,100,0) ,
          new ParDef("AV12NetworkIndividualAddressLine1",GXType.VarChar,100,0) ,
          new ParDef("AV13NetworkIndividualAddressLine2",GXType.VarChar,100,0) ,
          new ParDef("AV14NetworkIndividualPhoneCode",GXType.VarChar,40,0) ,
          new ParDef("AV15NetworkIndividualPhoneNumber",GXType.VarChar,9,0) ,
          new ParDef("AV16NetworkIndividualHomePhone",GXType.Char,20,0) ,
          new ParDef("AV17NetworkIndividualHomePhoneCode",GXType.VarChar,40,0) ,
          new ParDef("AV18NetworkIndividualHomePhoneNumb",GXType.VarChar,9,0) ,
          new ParDef("AV19NetworkIndividualRelationship",GXType.VarChar,400,0) ,
          new ParDef("AV20NetworkIndividualSalutation",GXType.Char,20,0){Nullable=true} ,
          new ParDef("AV21ResidentId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_NETWOR2", "SELECT NetworkIndividualRelationship, NetworkIndividualHomePhoneNumb, NetworkIndividualHomePhoneCode, NetworkIndividualHomePhone, NetworkIndividualPhoneNumber, NetworkIndividualPhoneCode, NetworkIndividualAddressLine2, NetworkIndividualAddressLine1, NetworkIndividualZipCode, NetworkIndividualCity, NetworkIndividualCountry, NetworkIndividualGender, NetworkIndividualPhone, NetworkIndividualEmail, NetworkIndividualLastName, NetworkIndividualGivenName, NetworkIndividualBsnNumber, NetworkIndividualId FROM Trn_NetworkIndividual ORDER BY NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_NETWOR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_NETWOR3", "INSERT INTO GXA0017(NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2, NetworkIndividualPhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualHomePhone, NetworkIndividualHomePhoneCode, NetworkIndividualHomePhoneNumb, NetworkIndividualRelationship, NetworkIndividualSalutation, ResidentId) VALUES(:AV2NetworkIndividualId, :AV3NetworkIndividualBsnNumber, :AV4NetworkIndividualGivenName, :AV5NetworkIndividualLastName, :AV6NetworkIndividualEmail, :AV7NetworkIndividualPhone, :AV8NetworkIndividualGender, :AV9NetworkIndividualCountry, :AV10NetworkIndividualCity, :AV11NetworkIndividualZipCode, :AV12NetworkIndividualAddressLine1, :AV13NetworkIndividualAddressLine2, :AV14NetworkIndividualPhoneCode, :AV15NetworkIndividualPhoneNumber, :AV16NetworkIndividualHomePhone, :AV17NetworkIndividualHomePhoneCode, :AV18NetworkIndividualHomePhoneNumb, :AV19NetworkIndividualRelationship, :AV20NetworkIndividualSalutation, :AV21ResidentId)", GxErrorMask.GX_NOMASK,prmTRN_NETWOR3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((Guid[]) buf[17])[0] = rslt.getGuid(18);
                return;
       }
    }

 }

}
