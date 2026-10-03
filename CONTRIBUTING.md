# Contributing

🐝 Thanks for stopping by! The Keepers are glad about every contribution — a bug report, a question,
a typo fix, a benchmark run on hardware we don't have, or a whole new algorithm. Small pull requests
and questions are just as welcome as big features.

Not sure where to start? Look for issues labelled
[`good first issue`](https://github.com/CryptoHives/Foundation/labels/good%20first%20issue) or
[`help wanted`](https://github.com/CryptoHives/Foundation/labels/help%20wanted), or just open an
issue and ask.

## Sign off your commits

We use the [Developer Certificate of Origin](https://github.com/CryptoHives/.github/blob/main/DCO.txt) (DCO) instead of a contributor
agreement: you keep the copyright in your work and contribute it under the project's license,
MIT OR Apache-2.0.
Add a sign-off to each commit — `git commit -s` does it for you:

```
Signed-off-by: Your Name <you@example.com>
```

With it you confirm that you wrote the change, or otherwise have the right to submit it under the
project's license. Forgot it? `git commit --amend -s` fixes the last commit, `git rebase --signoff main`
all commits on your branch — or just push one more commit whose message says you sign off the earlier
ones; the DCO check accepts that too.

## How we work

- **Say hello in an issue first** for anything bigger than a small fix, and mention that you'd like
  to work on it. That way nobody duplicates effort, and we can point you at the right corner of the
  code.
- **One topic per branch.** Fork the repo, branch off `main`, and keep each pull request to one
  issue — it makes the review much quicker.
- **Bring tests along.** The existing tests show the style; for cryptography that means the official
  test vectors from the specification, ideally cross-checked against a reference implementation.
- **Follow the surrounding code style.** The format check in CI will nudge you if something's off.
- **Write a commit message that explains why.** A one-line summary is fine for small changes; for
  bigger ones add a short paragraph on what changed and its impact, and reference the issue (`#123`).

Then push to your fork and open the pull request. CI builds and tests every target framework — if
something fails and it isn't obvious why, just ask in the PR and we'll help. We may suggest a few
changes before merging; that's a normal part of the conversation, not a rejection.

## Using AI tools

AI coding assistants (such as Claude and GitHub Copilot) are welcome — the maintainers use them too,
for boilerplate, tests, documentation and review. The one rule is ownership:

- You are responsible for the correctness, licensing and quality of what you submit, however it was
  written, and you should be able to explain every line of it.
- Cryptographic code must be checked against its specification and official test vectors.
- Make sure the tool hasn't reproduced someone else's code: keep its public-code filter on (for example
  GitHub Copilot's "block suggestions matching public code") or run a similarity check, and name the
  tool in the commit message with a `Co-authored-by:` line.
- An AI tool never adds a `Signed-off-by` line itself — only you can, after you have checked the code.
- Purely machine-generated pull requests without human understanding will be closed.

Treat AI output like a pull request from someone you don't know yet: verify it, test it, understand
it, then put your name on it.

## Be nice

Everyone here follows our short [Code of Conduct](https://github.com/CryptoHives/.github/blob/main/CODE_OF_CONDUCT.md).
Security problems go through a [private report](https://github.com/CryptoHives/Foundation/security/advisories/new),
never a public issue.
