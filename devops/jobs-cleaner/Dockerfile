FROM hjacobs/kube-job-cleaner:0.8
# every 10 second delete completed jobs older than a second
RUN ls -la
ENTRYPOINT ["/bin/ash", "-c", "while :; do ./cleaner.py --seconds 1; sleep 10; done"]
