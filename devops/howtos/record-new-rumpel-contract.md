
# spela in ett nytt konsumentdrivet kontrakt med rumpel
1. kör ```skaffold run -f devops/rumpel/skaffold.rumpelrecorder.contract.json```  
2. starta webbklienten och skapa en observation i gränssnittet
3. navigera till ./devops/rumpel och kopiera kontraktet från rumpelrecorder podden med:   
```kubectl cp default/$(kubectl get pod -l app=rumpelrecorder -o jsonpath="{.items[0].metadata.name}"):/app/contracts .```  

