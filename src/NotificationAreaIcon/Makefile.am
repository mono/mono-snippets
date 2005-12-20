SNIPPET_NAME = NotificationAreaIcon
SOURCES = \
	$(srcdir)/NotificationAreaIcon.cs \
	$(srcdir)/Sample.cs

# The following should not need editing unless you need to do something
# advanced, add a resource, reference, etc, etc, etc, etc

# If you need to add references to assemblies other than gtk-sharp-2.0, 
# be sure to keep them in sync with the MonoDevelop project file!!

ASSEMBLY = $(SNIPPET_NAME).exe

snippetsdir = $(pkglibdir)
snippets_SCRIPTS = $(ASSEMBLY)

all: $(ASSEMBLY)

run: all
	$(MONO) $(ASSEMBLY)

$(ASSEMBLY): $(SOURCES)
	$(MCS) -out:$(ASSEMBLY) $(GTKSHARP_LIBS) $(SOURCES)

EXTRA_DIST = $(SOURCES) snippet.mdp
CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb $(SNIPPET_NAME).pidb
DISTCLEANFILES = Makefile.in 

