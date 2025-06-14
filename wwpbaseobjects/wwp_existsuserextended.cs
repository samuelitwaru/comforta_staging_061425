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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_existsuserextended : GXProcedure
   {
      public wwp_existsuserextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_existsuserextended( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out bool aP1_Exists )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV8Exists = false ;
         initialize();
         ExecuteImpl();
         aP1_Exists=this.AV8Exists;
      }

      public bool executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_Exists);
         return AV8Exists ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out bool aP1_Exists )
      {
         this.AV9WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV8Exists = false ;
         SubmitImpl();
         aP1_Exists=this.AV8Exists;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Exists = false;
         /* Using cursor P001N2 */
         pr_default.execute(0, new Object[] {AV9WWPUserExtendedId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112WWPUserExtendedId = P001N2_A112WWPUserExtendedId[0];
            AV8Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P001N2_A112WWPUserExtendedId = new string[] {""} ;
         A112WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended__default(),
            new Object[][] {
                new Object[] {
               P001N2_A112WWPUserExtendedId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV9WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private bool AV8Exists ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001N2_A112WWPUserExtendedId ;
      private bool aP1_Exists ;
   }

   public class wwp_existsuserextended__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001N2;
          prmP001N2 = new Object[] {
          new ParDef("AV9WWPUserExtendedId",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001N2", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = ( :AV9WWPUserExtendedId) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                return;
       }
    }

 }

}
