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
   public class prc_getorganisationinformation : GXProcedure
   {
      public prc_getorganisationinformation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getorganisationinformation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_organisationId ,
                           out string aP1_response )
      {
         this.AV9organisationId = aP0_organisationId;
         this.AV11response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV11response;
      }

      public string executeUdp( Guid aP0_organisationId )
      {
         execute(aP0_organisationId, out aP1_response);
         return AV11response ;
      }

      public void executeSubmit( Guid aP0_organisationId ,
                                 out string aP1_response )
      {
         this.AV9organisationId = aP0_organisationId;
         this.AV11response = "" ;
         SubmitImpl();
         aP1_response=this.AV11response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXLvl1 = 0;
         /* Using cursor P00762 */
         pr_default.execute(0, new Object[] {AV9organisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00762_A11OrganisationId[0];
            A13OrganisationName = P00762_A13OrganisationName[0];
            A19OrganisationTypeId = P00762_A19OrganisationTypeId[0];
            A20OrganisationTypeName = P00762_A20OrganisationTypeName[0];
            A12OrganisationKvkNumber = P00762_A12OrganisationKvkNumber[0];
            A16OrganisationEmail = P00762_A16OrganisationEmail[0];
            A17OrganisationPhone = P00762_A17OrganisationPhone[0];
            A18OrganisationVATNumber = P00762_A18OrganisationVATNumber[0];
            A303OrganisationAddressCountry = P00762_A303OrganisationAddressCountry[0];
            A252OrganisationAddressCity = P00762_A252OrganisationAddressCity[0];
            A251OrganisationAddressZipCode = P00762_A251OrganisationAddressZipCode[0];
            A304OrganisationAddressLine1 = P00762_A304OrganisationAddressLine1[0];
            A305OrganisationAddressLine2 = P00762_A305OrganisationAddressLine2[0];
            A40000OrganisationLogo_GXI = P00762_A40000OrganisationLogo_GXI[0];
            A20OrganisationTypeName = P00762_A20OrganisationTypeName[0];
            AV14GXLvl1 = 1;
            AV13OrganisationDetails.gxTpr_Organisationid = A11OrganisationId;
            AV13OrganisationDetails.gxTpr_Organisationname = A13OrganisationName;
            AV13OrganisationDetails.gxTpr_Organisationtypeid = A19OrganisationTypeId;
            AV13OrganisationDetails.gxTpr_Organisationtypename = A20OrganisationTypeName;
            AV13OrganisationDetails.gxTpr_Organisationid = A11OrganisationId;
            AV13OrganisationDetails.gxTpr_Organisationkvknumber = A12OrganisationKvkNumber;
            AV13OrganisationDetails.gxTpr_Organisationemail = A16OrganisationEmail;
            AV13OrganisationDetails.gxTpr_Organisationphone = A17OrganisationPhone;
            AV13OrganisationDetails.gxTpr_Organisationvatnumber = A18OrganisationVATNumber;
            AV13OrganisationDetails.gxTpr_Organisationcountry = A303OrganisationAddressCountry;
            AV13OrganisationDetails.gxTpr_Organisationcity = A252OrganisationAddressCity;
            AV13OrganisationDetails.gxTpr_Organisationzipcode = A251OrganisationAddressZipCode;
            AV13OrganisationDetails.gxTpr_Organisationaddressline1 = A304OrganisationAddressLine1;
            AV13OrganisationDetails.gxTpr_Organisationaddressline2 = A305OrganisationAddressLine2;
            AV13OrganisationDetails.gxTpr_Organisationlogo = A40000OrganisationLogo_GXI;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl1 == 0 )
         {
            AV8isNotFound = true;
         }
         if ( AV8isNotFound )
         {
            AV11response = context.GetMessage( "No organisation record found!", "");
         }
         else
         {
            AV11response = AV13OrganisationDetails.ToJSonString(false, true);
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
         AV11response = "";
         P00762_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00762_A13OrganisationName = new string[] {""} ;
         P00762_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P00762_A20OrganisationTypeName = new string[] {""} ;
         P00762_A12OrganisationKvkNumber = new string[] {""} ;
         P00762_A16OrganisationEmail = new string[] {""} ;
         P00762_A17OrganisationPhone = new string[] {""} ;
         P00762_A18OrganisationVATNumber = new string[] {""} ;
         P00762_A303OrganisationAddressCountry = new string[] {""} ;
         P00762_A252OrganisationAddressCity = new string[] {""} ;
         P00762_A251OrganisationAddressZipCode = new string[] {""} ;
         P00762_A304OrganisationAddressLine1 = new string[] {""} ;
         P00762_A305OrganisationAddressLine2 = new string[] {""} ;
         P00762_A40000OrganisationLogo_GXI = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A13OrganisationName = "";
         A19OrganisationTypeId = Guid.Empty;
         A20OrganisationTypeName = "";
         A12OrganisationKvkNumber = "";
         A16OrganisationEmail = "";
         A17OrganisationPhone = "";
         A18OrganisationVATNumber = "";
         A303OrganisationAddressCountry = "";
         A252OrganisationAddressCity = "";
         A251OrganisationAddressZipCode = "";
         A304OrganisationAddressLine1 = "";
         A305OrganisationAddressLine2 = "";
         A40000OrganisationLogo_GXI = "";
         AV13OrganisationDetails = new SdtSDT_Organisation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getorganisationinformation__default(),
            new Object[][] {
                new Object[] {
               P00762_A11OrganisationId, P00762_A13OrganisationName, P00762_A19OrganisationTypeId, P00762_A20OrganisationTypeName, P00762_A12OrganisationKvkNumber, P00762_A16OrganisationEmail, P00762_A17OrganisationPhone, P00762_A18OrganisationVATNumber, P00762_A303OrganisationAddressCountry, P00762_A252OrganisationAddressCity,
               P00762_A251OrganisationAddressZipCode, P00762_A304OrganisationAddressLine1, P00762_A305OrganisationAddressLine2, P00762_A40000OrganisationLogo_GXI
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GXLvl1 ;
      private string A17OrganisationPhone ;
      private bool AV8isNotFound ;
      private string AV11response ;
      private string A13OrganisationName ;
      private string A20OrganisationTypeName ;
      private string A12OrganisationKvkNumber ;
      private string A16OrganisationEmail ;
      private string A18OrganisationVATNumber ;
      private string A303OrganisationAddressCountry ;
      private string A252OrganisationAddressCity ;
      private string A251OrganisationAddressZipCode ;
      private string A304OrganisationAddressLine1 ;
      private string A305OrganisationAddressLine2 ;
      private string A40000OrganisationLogo_GXI ;
      private Guid AV9organisationId ;
      private Guid A11OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00762_A11OrganisationId ;
      private string[] P00762_A13OrganisationName ;
      private Guid[] P00762_A19OrganisationTypeId ;
      private string[] P00762_A20OrganisationTypeName ;
      private string[] P00762_A12OrganisationKvkNumber ;
      private string[] P00762_A16OrganisationEmail ;
      private string[] P00762_A17OrganisationPhone ;
      private string[] P00762_A18OrganisationVATNumber ;
      private string[] P00762_A303OrganisationAddressCountry ;
      private string[] P00762_A252OrganisationAddressCity ;
      private string[] P00762_A251OrganisationAddressZipCode ;
      private string[] P00762_A304OrganisationAddressLine1 ;
      private string[] P00762_A305OrganisationAddressLine2 ;
      private string[] P00762_A40000OrganisationLogo_GXI ;
      private SdtSDT_Organisation AV13OrganisationDetails ;
      private string aP1_response ;
   }

   public class prc_getorganisationinformation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00762;
          prmP00762 = new Object[] {
          new ParDef("AV9organisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00762", "SELECT T1.OrganisationId, T1.OrganisationName, T1.OrganisationTypeId, T2.OrganisationTypeName, T1.OrganisationKvkNumber, T1.OrganisationEmail, T1.OrganisationPhone, T1.OrganisationVATNumber, T1.OrganisationAddressCountry, T1.OrganisationAddressCity, T1.OrganisationAddressZipCode, T1.OrganisationAddressLine1, T1.OrganisationAddressLine2, T1.OrganisationLogo_GXI FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId) WHERE T1.OrganisationId = :AV9organisationId ORDER BY T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getMultimediaUri(14);
                return;
       }
    }

 }

}
