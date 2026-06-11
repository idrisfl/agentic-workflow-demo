---
on:
  # Manual trigger so you can run it live during the demo
  workflow_dispatch: {}
  # Optional schedule: 07:30 UTC on weekdays
  schedule:
    - cron: "30 7 * * 1-5"

# GitHub-hosted public runner (no self-hosted runner needed)
runs-on: ubuntu-latest

permissions:
  contents: read
  issues: read
  pull-requests: read

engine: copilot

safe-outputs:
  create-issue:
    title-prefix: "[status] "
    labels: [report, daily-status]
    close-older-issues: true   # keep only the latest status issue
---

## Daily Status Report

Create a concise daily status report for this repository, posted as a GitHub issue.

## What to include

- **Open issues**: list each open issue with its number, title, and a one-line
  status. Note which acceptance-criteria checkboxes are checked vs unchecked.
- **Stale items**: flag any issue with no activity in the last 3 days.
- **Recently closed**: list issues closed in the last 24 hours.
- **PR activity**: any open or recently merged pull requests, with the issue they relate to.
- **Next steps**: 2-3 concrete, actionable recommendations for what to tackle next.

## Style

- Keep it short and scannable: use headings, bullets, and checkbox summaries.
- Be factual and upbeat; no filler.
- If there are no open issues, say so plainly and suggest creating some.
