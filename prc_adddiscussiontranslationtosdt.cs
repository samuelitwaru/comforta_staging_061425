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
   public class prc_adddiscussiontranslationtosdt : GXProcedure
   {
      public prc_adddiscussiontranslationtosdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_adddiscussiontranslationtosdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPDiscussionMessageId ,
                           out SdtSDT_DiscussionTranslation aP1_SDT_DiscussionTranslation )
      {
         this.AV9WWPDiscussionMessageId = aP0_WWPDiscussionMessageId;
         this.AV8SDT_DiscussionTranslation = new SdtSDT_DiscussionTranslation(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_DiscussionTranslation=this.AV8SDT_DiscussionTranslation;
      }

      public SdtSDT_DiscussionTranslation executeUdp( long aP0_WWPDiscussionMessageId )
      {
         execute(aP0_WWPDiscussionMessageId, out aP1_SDT_DiscussionTranslation);
         return AV8SDT_DiscussionTranslation ;
      }

      public void executeSubmit( long aP0_WWPDiscussionMessageId ,
                                 out SdtSDT_DiscussionTranslation aP1_SDT_DiscussionTranslation )
      {
         this.AV9WWPDiscussionMessageId = aP0_WWPDiscussionMessageId;
         this.AV8SDT_DiscussionTranslation = new SdtSDT_DiscussionTranslation(context) ;
         SubmitImpl();
         aP1_SDT_DiscussionTranslation=this.AV8SDT_DiscussionTranslation;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00EA2 */
         pr_default.execute(0, new Object[] {AV9WWPDiscussionMessageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A200WWPDiscussionMessageId = P00EA2_A200WWPDiscussionMessageId[0];
            A204WWPDiscussionMessageMessage = P00EA2_A204WWPDiscussionMessageMessage[0];
            AV8SDT_DiscussionTranslation.gxTpr_Discussiontranslationwwpdiscussionmessageid = (int)(A200WWPDiscussionMessageId);
            AV8SDT_DiscussionTranslation.gxTpr_Discussiontranslationvalue = A204WWPDiscussionMessageMessage;
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
         AV8SDT_DiscussionTranslation = new SdtSDT_DiscussionTranslation(context);
         P00EA2_A200WWPDiscussionMessageId = new long[1] ;
         P00EA2_A204WWPDiscussionMessageMessage = new string[] {""} ;
         A204WWPDiscussionMessageMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_adddiscussiontranslationtosdt__default(),
            new Object[][] {
                new Object[] {
               P00EA2_A200WWPDiscussionMessageId, P00EA2_A204WWPDiscussionMessageMessage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9WWPDiscussionMessageId ;
      private long A200WWPDiscussionMessageId ;
      private string A204WWPDiscussionMessageMessage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_DiscussionTranslation AV8SDT_DiscussionTranslation ;
      private IDataStoreProvider pr_default ;
      private long[] P00EA2_A200WWPDiscussionMessageId ;
      private string[] P00EA2_A204WWPDiscussionMessageMessage ;
      private SdtSDT_DiscussionTranslation aP1_SDT_DiscussionTranslation ;
   }

   public class prc_adddiscussiontranslationtosdt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EA2;
          prmP00EA2 = new Object[] {
          new ParDef("AV9WWPDiscussionMessageId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EA2", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageMessage FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :AV9WWPDiscussionMessageId ORDER BY WWPDiscussionMessageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
