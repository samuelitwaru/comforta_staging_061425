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
   public class prc_addcalltoactionattributestosdt : GXProcedure
   {
      public prc_addcalltoactionattributestosdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addcalltoactionattributestosdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CallToActionId ,
                           out SdtSDT_TrnAttributes aP1_SDT_TrnAttributes )
      {
         this.AV11CallToActionId = aP0_CallToActionId;
         this.AV10SDT_TrnAttributes = new SdtSDT_TrnAttributes(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_TrnAttributes=this.AV10SDT_TrnAttributes;
      }

      public SdtSDT_TrnAttributes executeUdp( Guid aP0_CallToActionId )
      {
         execute(aP0_CallToActionId, out aP1_SDT_TrnAttributes);
         return AV10SDT_TrnAttributes ;
      }

      public void executeSubmit( Guid aP0_CallToActionId ,
                                 out SdtSDT_TrnAttributes aP1_SDT_TrnAttributes )
      {
         this.AV11CallToActionId = aP0_CallToActionId;
         this.AV10SDT_TrnAttributes = new SdtSDT_TrnAttributes(context) ;
         SubmitImpl();
         aP1_SDT_TrnAttributes=this.AV10SDT_TrnAttributes;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DM2 */
         pr_default.execute(0, new Object[] {AV11CallToActionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A339CallToActionId = P00DM2_A339CallToActionId[0];
            A368CallToActionName = P00DM2_A368CallToActionName[0];
            AV10SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
            AV10SDT_TrnAttributes.gxTpr_Trnname = "Trn_CallToAction";
            AV10SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Primarykeyid = A339CallToActionId;
            AV8Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
            AV8Attribute.gxTpr_Attributename = "CallToActionName";
            AV8Attribute.gxTpr_Attributevalue = A368CallToActionName;
            AV10SDT_TrnAttributes.gxTpr_Transaction.gxTpr_Attribute.Add(AV8Attribute, 0);
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
         AV10SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         P00DM2_A339CallToActionId = new Guid[] {Guid.Empty} ;
         P00DM2_A368CallToActionName = new string[] {""} ;
         A339CallToActionId = Guid.Empty;
         A368CallToActionName = "";
         AV8Attribute = new SdtSDT_TrnAttributes_Transaction_AttributeItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addcalltoactionattributestosdt__default(),
            new Object[][] {
                new Object[] {
               P00DM2_A339CallToActionId, P00DM2_A368CallToActionName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A368CallToActionName ;
      private Guid AV11CallToActionId ;
      private Guid A339CallToActionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_TrnAttributes AV10SDT_TrnAttributes ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DM2_A339CallToActionId ;
      private string[] P00DM2_A368CallToActionName ;
      private SdtSDT_TrnAttributes_Transaction_AttributeItem AV8Attribute ;
      private SdtSDT_TrnAttributes aP1_SDT_TrnAttributes ;
   }

   public class prc_addcalltoactionattributestosdt__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DM2;
          prmP00DM2 = new Object[] {
          new ParDef("AV11CallToActionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DM2", "SELECT CallToActionId, CallToActionName FROM Trn_CallToAction WHERE CallToActionId = :AV11CallToActionId ORDER BY CallToActionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
