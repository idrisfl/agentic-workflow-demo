---
on:
  # Fires automatically when the CI workflow finishes
  workflow_run:
    workflows: ["CI"]
    types: [completed]
    branches:
      - main
  # Manual trigger so you can demo it on demand
  workflow_dispatch: {}

# Only proceed when the CI run actually failed
if: ${{ github.event_name == 'workflow_dispatch' || github.event.workflow_run.conclusion == 'failure' }}

runs-on: ubuntu-latest

permissions:
  contents: read
  actions: read
  pull-requests: read

engine: copilot

tools:
  edit:

safe-outputs:
  create-pull-request:
    title-prefix: "[auto-fix] "
    labels: [automated, test-fix]
    draft: true
---

# Self-Healing CI: Fix Failing Tests

The continuous integration (`CI`) workflow for this .NET 10 repository has reported
one or more **failing unit tests**. Your job is to diagnose the failure, implement a
minimal correct fix, and open a **draft pull request** with the change.

## Steps

1. **Read the failing tests** under `tests/`. They encode the *correct* expected
   behavior (the `Assert` calls show the expected values) — trust them.
2. **Locate the root cause**: The code under test lives under `src/`. Read it and
   compare it against what the tests expect. Find the bug in the source, not the tests.
3. **Fix minimally**: Edit only what is needed in `src/` to make the failing tests
   pass. Do **not** edit the test files. Do **not** refactor unrelated code.
4. **Open a draft PR** with your fix.

## Pull request content

- **Title**: A short, specific summary of the fix.
- **Body**:
  - **Root cause**: 1-2 sentences explaining the actual bug.
  - **Fix**: What you changed and why it is correct.
  - Keep it concise and factual.

## Constraints

- Touch the smallest possible number of lines.
- Never weaken or delete a test to make it pass.
- If you cannot determine a safe fix, open the PR as draft and clearly describe what
  you found and what is still uncertain.
