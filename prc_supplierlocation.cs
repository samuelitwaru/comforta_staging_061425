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
   public class prc_supplierlocation : GXProcedure
   {
      public prc_supplierlocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_supplierlocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductServiceGroup ,
                           out string aP1_ServiceGroup )
      {
         this.AV8ProductServiceGroup = aP0_ProductServiceGroup;
         this.AV11ServiceGroup = "" ;
         initialize();
         ExecuteImpl();
         aP1_ServiceGroup=this.AV11ServiceGroup;
      }

      public string executeUdp( string aP0_ProductServiceGroup )
      {
         execute(aP0_ProductServiceGroup, out aP1_ServiceGroup);
         return AV11ServiceGroup ;
      }

      public void executeSubmit( string aP0_ProductServiceGroup ,
                                 out string aP1_ServiceGroup )
      {
         this.AV8ProductServiceGroup = aP0_ProductServiceGroup;
         this.AV11ServiceGroup = "" ;
         SubmitImpl();
         aP1_ServiceGroup=this.AV11ServiceGroup;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Trn_Location = new SdtTrn_Location(context);
         AV10LocationId = StringUtil.StrToGuid( AV8ProductServiceGroup);
         /* Using cursor P008U2 */
         pr_default.execute(0, new Object[] {AV10LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P008U2_A29LocationId[0];
            A31LocationName = P008U2_A31LocationName[0];
            A11OrganisationId = P008U2_A11OrganisationId[0];
            AV11ServiceGroup = A31LocationName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV11ServiceGroup = "";
         AV9Trn_Location = new SdtTrn_Location(context);
         AV10LocationId = Guid.Empty;
         P008U2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008U2_A31LocationName = new string[] {""} ;
         P008U2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_supplierlocation__default(),
            new Object[][] {
                new Object[] {
               P008U2_A29LocationId, P008U2_A31LocationName, P008U2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8ProductServiceGroup ;
      private string AV11ServiceGroup ;
      private string A31LocationName ;
      private Guid AV10LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Location AV9Trn_Location ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008U2_A29LocationId ;
      private string[] P008U2_A31LocationName ;
      private Guid[] P008U2_A11OrganisationId ;
      private string aP1_ServiceGroup ;
   }

   public class prc_supplierlocation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008U2;
          prmP008U2 = new Object[] {
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008U2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location WHERE LocationId = :AV10LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008U2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
