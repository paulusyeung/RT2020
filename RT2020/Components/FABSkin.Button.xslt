<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:WC="wgcontrols">
  
  <!-- Draw the button content -->
  <xsl:template match="WC:Tags.Button[@Attr.CustomStyle='FABSkin']" mode="modFrameCenterContent">
      <xsl:param name="prmIsEnabled" select="@Attr.Enabled"/>
      <xsl:call-template name="tplDrawButtonContentAPI">
      <xsl:with-param name="prmFontDataClass" select="'Button-FontData'"/>
      <xsl:with-param name="prmDropDownArrowImage" select="'[Skin.DropDownArrowImage]'"/>
      <xsl:with-param name="prmIsEnabled" select="$prmIsEnabled"/>
      <xsl:with-param name="prmImageEnabledClass" select="'Button-Image'"/>
      <xsl:with-param name="prmImageDisabledClass" select="'Button-Image_Disabled'"/>
    </xsl:call-template>
  </xsl:template>

</xsl:stylesheet>
