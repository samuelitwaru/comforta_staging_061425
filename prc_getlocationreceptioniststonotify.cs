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
   public class prc_getlocationreceptioniststonotify : GXProcedure
   {
      public prc_getlocationreceptioniststonotify( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_getlocationreceptioniststonotify( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           out GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem> aP1_SDT_ReceptionistsToNotify )
      {
         this.AV2WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV3SDT_ReceptionistsToNotify = new GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>( context, "SDT_ReceptionistToNotifiyItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_ReceptionistsToNotify=this.AV3SDT_ReceptionistsToNotify;
      }

      public GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem> executeUdp( string aP0_WWPUserExtendedId )
      {
         execute(aP0_WWPUserExtendedId, out aP1_SDT_ReceptionistsToNotify);
         return AV3SDT_ReceptionistsToNotify ;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 out GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem> aP1_SDT_ReceptionistsToNotify )
      {
         this.AV2WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV3SDT_ReceptionistsToNotify = new GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>( context, "SDT_ReceptionistToNotifiyItem", "Comforta_version2") ;
         SubmitImpl();
         aP1_SDT_ReceptionistsToNotify=this.AV3SDT_ReceptionistsToNotify;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2WWPUserExtendedId,(GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>)AV3SDT_ReceptionistsToNotify} ;
         ClassLoader.Execute("aprc_getlocationreceptioniststonotify","GeneXus.Programs","aprc_getlocationreceptioniststonotify", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3SDT_ReceptionistsToNotify = (GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>)(args[1]) ;
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
      }

      public override void initialize( )
      {
         AV3SDT_ReceptionistsToNotify = new GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>( context, "SDT_ReceptionistToNotifiyItem", "Comforta_version2");
         /* GeneXus formulas. */
      }

      private string AV2WWPUserExtendedId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem> AV3SDT_ReceptionistsToNotify ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem> aP1_SDT_ReceptionistsToNotify ;
   }

}
