| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 128B         |   7.910 μs | 0.0443 μs | 0.0592 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 128B         |  10.382 μs | 0.0489 μs | 0.0433 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 1KB          |  10.998 μs | 0.0823 μs | 0.0729 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 1KB          |  14.668 μs | 0.0671 μs | 0.0560 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 8KB          |  36.626 μs | 0.6365 μs | 1.0808 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 8KB          |  48.784 μs | 0.2752 μs | 0.2440 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 128KB        | 468.594 μs | 3.3391 μs | 2.9600 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 128KB        | 636.513 μs | 4.3272 μs | 4.0477 μs |         - |