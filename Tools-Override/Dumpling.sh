#~/usr/bin/env bash
if [ ! -f ~/.dumpling/dumpling.py ]
then
  echo Dumpling not found, installing...
  #download the dumpling client
  wget https://dumpling.azurewebsites.net/api/client/dumpling.py
  #install and make sure the client script is up to date
  python dumpling.py install --update
  python ~/.dumpling/dumpling.py install --full
fi
#set the rlimit for coredumps
echo executing ulimit -c unlimited
ulimit -c unlimited
echo 0x3F > /proc/self/coredump_filter


function CollectDumps()
{
  _EXITCODE=$1
  _ProjectName=$2
  echo command exited with ExitCode: $_EXITCODE
  if [ $_EXITCODE != 0 ]
  then
    echo command failed, trying to collect dumps
    _corefile=$(ls . | grep -E --max-count=1 core\\.)
    echo corefile: $_corefile
    if [[ -n $_corefile ]]
    then
      echo uploading core to dumpling service
      python ~/.dumpling/dumpling.py upload --dumppath $_corefile --noprompt --triage full --displayname $_ProjectName --properties STRESS_TESTID=$_ProjectName --verbose
    else
      echo no coredump file was found
    fi
  fi
  return $_EXITCODE
}
