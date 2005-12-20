AC_INIT(README)
AC_CANONICAL_SYSTEM

AM_INIT_AUTOMAKE(mono-snippets, 0.1)

AM_MAINTAINER_MODE

AC_PATH_PROG(MONO, mono, no)
if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([Cannot find "mono" runtime in your PATH])
fi

AC_PATH_PROG(MCS, mcs, no)
if test "x$MCS" = "xno"; then
	AC_MSG_ERROR([Cannot find "mcs" compiler in your PATH])
fi

PKG_CHECK_MODULES(GTKSHARP, gtk-sharp-2.0 >= 2.3.92)
AC_SUBST(GTKSHARP_LIBS)

AC_OUTPUT([
	Makefile
	src/Makefile
	src/NotificationAreaIcon/Makefile
])

echo "
   ** Note: There is no need to run \`make install' ** 
      You can test the snippet examples simply by 
      running \`make run' in the respective snippet
      source directory.

      \`make install' still works however.
"

