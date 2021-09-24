
# record a new contract with Rumpel
1.  run: ```skaffold run -f devops/rumpel/skaffold.rumpelrecorder.contract.json```  
2. In your browser navigate to http://localhost and create an observation
3. In your terminal navigate to ./devops/rumpel and copy the created contract from the running rumpel-recorder pod:   
```kubectl cp default/$(kubectl get pod -l app=rumpelrecorder -o jsonpath="{.items[0].metadata.name}"):/app/contracts .```  

