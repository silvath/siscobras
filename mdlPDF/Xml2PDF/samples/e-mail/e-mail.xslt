<?xml version="1.0" encoding="UTF-8"?>
<!-- edited with XMLSPY v5 rel. 3 U (http://www.xmlspy.com) by 2 (1) -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output indent="yes"/>
	<xsl:template match="email">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format" font-size="12pt" font-family="Courier">
			<fo:layout-master-set>
				<fo:simple-page-master master-name="main-page-master" page-width="21cm" page-height="29.7cm" margin="1cm">
					<fo:region-body region-name="xsl-region-body" padding="1cm" border="1pt solid black"/>
				</fo:simple-page-master>
			</fo:layout-master-set>
			<fo:page-sequence master-reference="main-page-master">
				<fo:flow flow-name="xsl-region-body" font-family="Courier">
					<fo:block language="ru" country="ru">
						<xsl:apply-templates select="header"/>
						<xsl:apply-templates select="body"/>
					</fo:block>
					<fo:block id="end-of-document"/>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
	<xsl:template match="header">
		<fo:table width="100%" border="1pt solid black" table-layout="auto">
			<fo:table-column column-number="1" column-width="25%" background-color="lightgray"/>
			<fo:table-column column-number="2" column-width="75%"/>
			<fo:table-body>
				<fo:table-row>
					<fo:table-cell font-weight="bold" padding="2pt" border="1pt solid black">
						<fo:block>TO:</fo:block>
					</fo:table-cell>
					<fo:table-cell padding="2pt" border="1pt solid black">
						<xsl:apply-templates select="to"/>
					</fo:table-cell>
				</fo:table-row>
				<fo:table-row>
					<fo:table-cell font-weight="bold" padding="2pt" border="1pt solid black">
						<fo:block>CC:</fo:block>
					</fo:table-cell>
					<fo:table-cell padding="2pt" border="1pt solid black">
						<xsl:apply-templates select="cc"/>
					</fo:table-cell>
				</fo:table-row>
				<fo:table-row>
					<fo:table-cell font-weight="bold" padding="2pt" border="1pt solid black">
						<fo:block>BCC:</fo:block>
					</fo:table-cell>
					<fo:table-cell padding="2pt" border="1pt solid black">
						<xsl:apply-templates select="bcc"/>
					</fo:table-cell>
				</fo:table-row>
				<fo:table-row>
					<fo:table-cell font-weight="bold" padding="2pt" border="1pt solid black">
						<fo:block>Subject:</fo:block>
					</fo:table-cell>
					<fo:table-cell padding="2pt" border="1pt solid black">
						<xsl:apply-templates select="subject"/>
					</fo:table-cell>
				</fo:table-row>
			</fo:table-body>
		</fo:table>
	</xsl:template>

	<xsl:template match="to">
		<fo:block>
				<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>

	<xsl:template match="cc">
		<fo:block>
				<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>
	<xsl:template match="bcc">
		<fo:block>
				<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>

	<xsl:template match="subject">
		<fo:block>
				<xsl:value-of select="."/>
		</fo:block>
	</xsl:template>
	
	<xsl:template match="body">
		<fo:block>
			<fo:leader leader-pattern="space" leader-length="100%"/>
		</fo:block>
		<fo:block font-size="12pt" font-family="Helvetica">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>
	
	<xsl:template match="b">
		<fo:wrapper font-weight="bold">
			<xsl:apply-templates/>
		</fo:wrapper>
	</xsl:template>
	
	<xsl:template match="i">
		<fo:wrapper font-style="italic">
			<xsl:apply-templates/>
		</fo:wrapper>
	</xsl:template>
	
	<xsl:template match="u">
		<fo:wrapper text-decoration="underline">
			<xsl:apply-templates/>
		</fo:wrapper>
	</xsl:template>
	
	<xsl:template match="p">
		<fo:block margin-top="10pt">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>

	<xsl:template match="p">
		<fo:block margin-top="10pt">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>

	<xsl:template match="br">
		<fo:block>
			<fo:character character=" "/>
		</fo:block>
	</xsl:template>

	<xsl:template match="tag">&lt;<xsl:apply-templates/>&gt;</xsl:template>

</xsl:stylesheet>
