<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output indent="yes"/>
	<xsl:template match="letter">
		<fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format" font-family="Helvetica" font-size="10pt">
		
			<fo:layout-master-set>
				<fo:simple-page-master master-name="all-pages" page-height="29.7cm" page-width="21cm" margin="1cm">
					<fo:region-body   region-name="xsl-region-body"   background-color="white" margin-bottom="1cm" margin-top="1cm"/>
					<fo:region-before region-name="xsl-region-before"  background-color="#EFF0D7" extent="1cm" border="1pt solid #		660000"/>
					<fo:region-after  region-name="xsl-region-after"  background-color="#EFF0D7" extent="1cm" border="1pt solid #		660000"/>
				</fo:simple-page-master>
			</fo:layout-master-set>
			
			<fo:page-sequence master-reference="all-pages">
				
				<fo:static-content flow-name="xsl-region-before">
					<fo:block text-align="justify" text-align-last="justify" padding="0.25cm">
						<fo:wrapper color="#660000" font-size="12pt" font-weight="bold">ALTSOFT</fo:wrapper><fo:leader/><fo:wrapper font-style="italic">Shaping your inspirations</fo:wrapper>
					</fo:block>
				</fo:static-content>
				
				<fo:static-content flow-name="xsl-region-after">
					<fo:block text-align="justify" text-align-last="justify" padding="0.25cm">
						<fo:basic-link external-destination="url(http://www.alt-soft.com/)"><fo:inline color="#660000" text-decoration="underline">http://www.alt-soft.com/</fo:inline></fo:basic-link><fo:leader/><fo:inline wrap-option="no-wrap">© 		Altsoft, 2003</fo:inline>
					</fo:block>
				</fo:static-content>
				
			<fo:flow flow-name="xsl-region-body" font-family="Courier" font-size="10pt">
				<fo:block margin="1.5cm" text-align="justify" text-align-last="left">
					<fo:block linefeed-treatment="preserve">
						<!-- ADDRESS -->
						<fo:block text-align="right" text-align-last="right">
							<xsl:value-of select="address"/>
						</fo:block>
						<!-- /ADDRESS -->
						<fo:block><fo:character character=" "/></fo:block>
						<!-- DATE -->
						<fo:block text-align="right" text-align-last="right">
							<xsl:value-of select="date"/>
						</fo:block>
						<!-- /DATE -->
						<fo:block padding="1cm"><fo:character character=" "/></fo:block>
						<!-- NAME -->
						<fo:block>
							<xsl:value-of select="name"/>
						</fo:block>
						<!-- /NAME -->
						<fo:block>
							<xsl:value-of select="begin"/>
						</fo:block>
						<fo:block padding="1.5cm"><fo:character character=" "/></fo:block>
						<!-- OPENING -->
						<fo:block>
							<xsl:value-of select="opening"/>
						</fo:block>
						<!-- /OPENING -->
						<fo:block><fo:character character=" "/></fo:block>
						<!-- BODY -->
						<fo:block text-align="justify">
							<xsl:value-of select="body"/>
						</fo:block>
						<!-- /BODY -->
						<fo:block><fo:character character=" "/></fo:block>
						<!-- CLOSING -->
						<fo:block text-align="right" text-align-last="right">
							<fo:block><xsl:value-of select="closing"/></fo:block>
							<fo:block><fo:character character=" "/></fo:block>
							<fo:block><xsl:value-of select="name"/></fo:block>
						</fo:block>
						<!-- /CLOSING -->
						<fo:block padding="1.5cm"><fo:character character=" "/></fo:block>
						<!-- PS -->
						<fo:list-block>
							<fo:list-item>
								<fo:list-item-label>
									<fo:block>PS:</fo:block>
								</fo:list-item-label>
								<fo:list-item-body>
									<fo:block text-align="justify"><xsl:value-of select="ps"/></fo:block>
								</fo:list-item-body>
							</fo:list-item>
						</fo:list-block>
						<!-- /PS -->
						<fo:block><fo:character character=" "/></fo:block>
						<!-- CC -->
						<fo:list-block>
							<fo:list-item>
								<fo:list-item-label>
									<fo:block>cc:</fo:block>
								</fo:list-item-label>
								<fo:list-item-body>
									<fo:block><xsl:value-of select="cc"/></fo:block>
								</fo:list-item-body>
							</fo:list-item>
						</fo:list-block>
						<!-- /CC -->
						<fo:block><fo:character character=" "/></fo:block>
						<!-- ENCL -->
						<fo:list-block>
							<fo:list-item>
								<fo:list-item-label>
									<fo:block>encl:</fo:block>
								</fo:list-item-label>
								<fo:list-item-body>
									<fo:block text-align="justify"><xsl:value-of select="encl"/></fo:block>
								</fo:list-item-body>
							</fo:list-item>
						</fo:list-block>
						<!-- /ENCL -->
						</fo:block>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
	
</xsl:stylesheet>
