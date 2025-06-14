using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_logger : GXProcedure
   {
      public wwp_logger( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_logger( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         cleanup();
      }

      public void gxep_debug( string aP0_Topic ,
                              string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         /* Debug Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).debug(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         ExecuteImpl();
         cleanup();
      }

      public void gxep_info( string aP0_Topic ,
                             string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         /* Info Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).info(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         ExecuteImpl();
         cleanup();
      }

      public void gxep_warning( string aP0_Topic ,
                                string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         /* Warning Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).warning(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         ExecuteImpl();
         cleanup();
      }

      public void gxep_error( string aP0_Topic ,
                              string aP1_Message )
      {
         this.AV10Topic = aP0_Topic;
         this.AV9Message = aP1_Message;
         initialize();
         /* Error Constructor */
         /* Execute user subroutine: 'FORMATMESSAGE' */
         S111 ();
         if ( returnInSub )
         {
            returnInSub = true;
            cleanup();
            if (true) return;
         }
         new GeneXus.Core.genexus.common.SdtLog(context).error(AV8FormattedMessage, StringUtil.Trim( AV10Topic)) ;
         ExecuteImpl();
         cleanup();
      }

      protected void S111( )
      {
         /* 'FORMATMESSAGE' Routine */
         returnInSub = false;
         AV8FormattedMessage = "";
         GXt_char1 = AV11WWPUserExtendedId;
         new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         AV11WWPUserExtendedId = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WWPUserExtendedId)) )
         {
            AV8FormattedMessage += StringUtil.Format( "[UserGUID: %1] ", StringUtil.Trim( AV11WWPUserExtendedId), "", "", "", "", "", "", "", "");
         }
         else
         {
            AV8FormattedMessage += StringUtil.Format( "[UserGUID: %1] ", "N/A", "", "", "", "", "", "", "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WWPUserExtendedId)) )
         {
            AV8FormattedMessage += StringUtil.Format( "[UserName: %1] ", StringUtil.Trim( AV11WWPUserExtendedId), "", "", "", "", "", "", "", "");
         }
         else
         {
            AV8FormattedMessage += StringUtil.Format( "[UserName: %1] ", "N/A", "", "", "", "", "", "", "", "");
         }
         AV8FormattedMessage += StringUtil.Trim( AV9Message);
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
         AV8FormattedMessage = "";
         AV11WWPUserExtendedId = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string AV11WWPUserExtendedId ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string AV10Topic ;
      private string AV9Message ;
      private string AV8FormattedMessage ;
   }

}
