<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output indent="yes"/>
	<xsl:template match="diagram">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format" font-family="Helvetica" font-size="10pt">
			<fo:layout-master-set>
				<fo:simple-page-master master-name="all-pages" page-height="29.7cm" page-width="21cm" margin="1cm">
					<fo:region-body   region-name="xsl-region-body"   background-color="white" margin-bottom="1cm" margin-top="1cm"/>
					<fo:region-before region-name="xsl-region-before"  background-color="#EFF0D7" extent="1cm" border="1pt solid #660000"/>
					<fo:region-after  region-name="xsl-region-after"  background-color="#EFF0D7" extent="1cm" border="1pt solid #660000"/>
				</fo:simple-page-master>
			</fo:layout-master-set>
		
			<fo:page-sequence master-reference="all-pages">
				<fo:static-content flow-name="xsl-region-before">
					<fo:block text-align="justify" text-align-last="justify" padding="0.25cm">
						<fo:wrapper color="#660000" font-size="12pt" font-weight="bold">ALTSOFT</fo:wrapper><fo:leader/>XSL-FO testsuite
					</fo:block>
				</fo:static-content>
				<fo:static-content flow-name="xsl-region-after">
					<fo:block text-align="justify" text-align-last="justify" padding="0.25cm">
						<fo:basic-link external-destination="url(http://www.alt-soft.com/)"><fo:inline color="#660000" text-decoration="underline">http://www.alt-soft.com/</fo:inline></fo:basic-link><fo:leader/><fo:inline wrap-option="no-wrap">© Altsoft, 2003</fo:inline>
					</fo:block>
				</fo:static-content>
				<fo:flow flow-name="xsl-region-body" font-family="Courier" font-size="10pt">
					<fo:block margin="1.5cm">
						<xsl:apply-templates select="title"/>
						<fo:block margin="0.5cm">
							<xsl:apply-templates select="description"/>
							<xsl:apply-templates select="values"/>
						</fo:block>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>

	<xsl:template match="title">
		<fo:block font-family="Helvetica" font-size="14pt" background-color="lightgrey" padding="4pt">
			<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>

	<xsl:template match="description">
		<fo:block font-family="Times" font-size="12pt"  text-align="justify" text-align-last="left">
			<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>

	<xsl:template match="values">
		 <fo:block border="1pt solid black" padding="0.5cm" margin-bottom="0.5cm" margin-top="0.5cm">
			 <fo:table width="100%">
				<fo:table-body>
					<fo:table-row>
						<xsl:apply-templates select="item"/>
					</fo:table-row>
				</fo:table-body>
			</fo:table>
		</fo:block>
		<fo:table-and-caption>
			<fo:table-caption>
				<fo:block>Legend</fo:block>
			</fo:table-caption>
			<fo:table border="1pt solid black">
			<fo:table-body>
	
					<xsl:for-each select="item">
						<fo:table-row margin="0.1cm">
							<fo:table-cell>
								<fo:block color="{color}" padding="5pt"><xsl:value-of select="color"/></fo:block>
							</fo:table-cell>
							<fo:table-cell wrap-option="no-wrap">
								<fo:block padding="5pt"><xsl:value-of select="name"/></fo:block>
							</fo:table-cell>
							<fo:table-cell wrap-option="no-wrap">
								<fo:block padding="5pt"><xsl:value-of select="value"/>%</fo:block>
							</fo:table-cell>
						</fo:table-row>
					</xsl:for-each>
	
				</fo:table-body>
			</fo:table>
		</fo:table-and-caption>
	</xsl:template>

	<xsl:template match="item">
			<fo:table-cell background-color="{color}" width="{value}%" height="1cm">
				<fo:block>
					<fo:leader/>
				</fo:block>
			</fo:table-cell>
	</xsl:template>

</xsl:stylesheet>
