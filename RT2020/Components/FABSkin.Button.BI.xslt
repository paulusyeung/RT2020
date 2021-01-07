<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='FABSkin']" mode="modContent">
    <xsl:param name="prmIsEnabled" />
    <xsl:call-template name="tplDrawButtonAPI">
      <xsl:with-param name="prmButtonClass" select="'Button-Control'" />
      <xsl:with-param name="prmLeftBottomClass" select="''" />
      <xsl:with-param name="prmLeftClass" select="''" />
      <xsl:with-param name="prmLeftTopClass" select="''" />
      <xsl:with-param name="prmTopClass" select="''" />
      <xsl:with-param name="prmRightTopClass" select="''" />
      <xsl:with-param name="prmRightClass" select="''" />
      <xsl:with-param name="prmRightBottomClass" select="''" />
      <xsl:with-param name="prmBottomClass" select="''" />
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'" />
      <xsl:with-param name="prmCenterClass" select="'Button-Center'" />
      <xsl:with-param name="prmCenterTransparentClass" select="'Button-CenterTransparent'" />
      <xsl:with-param name="prmContentClass" select="''" />
      <xsl:with-param name="prmLeftFrameWidth" select="0" />
      <xsl:with-param name="prmRightFrameWidth" select="0" />
      <xsl:with-param name="prmTopFrameHeight" select="0" />
      <xsl:with-param name="prmBottomFrameHeight" select="0" />
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled" />
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
