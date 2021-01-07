<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols" xmlns:WG="http://www.gizmox.com/webgui">

  <!-- Draws the content of a normal button -->
  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='FABSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawButtonAPI">
      <xsl:with-param name="prmButtonClass" select="'Button-Control'" />
      <xsl:with-param name="prmLeftBottomClass" select="'Button-BottomLeft'" />
      <xsl:with-param name="prmLeftClass" select="'Button-Left'" />
      <xsl:with-param name="prmLeftTopClass" select="'Button-TopLeft'" />
      <xsl:with-param name="prmTopClass" select="'Button-Top'" />
      <xsl:with-param name="prmRightTopClass" select="'Button-TopRight'" />
      <xsl:with-param name="prmRightClass" select="'Button-Right'" />
      <xsl:with-param name="prmRightBottomClass" select="'Button-BottomRight'" />
      <xsl:with-param name="prmBottomClass" select="'Button-Bottom'" />
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'" />
      <xsl:with-param name="prmCenterClass" select="'Button-Center'" />
      <xsl:with-param name="prmCenterTransparentClass" select="'Button-CenterTransparent'" />
      <xsl:with-param name="prmContentClass" select="'Button-Content'" />

      <xsl:with-param name="prmLeftFrameWidth" select="[Skin.LeftFrameWidth]" />
      <xsl:with-param name="prmRightFrameWidth" select="[Skin.RightFrameWidth]" />
      <xsl:with-param name="prmTopFrameHeight" select="[Skin.TopFrameHeight]" />
      <xsl:with-param name="prmBottomFrameHeight" select="[Skin.BottomFrameHeight]" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>
  
</xsl:stylesheet>
