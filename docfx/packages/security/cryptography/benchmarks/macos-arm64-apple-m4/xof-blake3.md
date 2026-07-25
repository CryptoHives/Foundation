| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.653 μs | 0.0024 μs | 0.0023 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.989 μs | 0.0010 μs | 0.0009 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.991 μs | 0.0016 μs | 0.0015 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.088 μs | 0.0052 μs | 0.0048 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.116 μs | 0.0053 μs | 0.0049 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.745 μs | 0.0134 μs | 0.0125 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.286 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.456 μs | 0.0041 μs | 0.0039 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.742 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.848 μs | 0.0016 μs | 0.0015 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.866 μs | 0.0029 μs | 0.0028 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.796 μs | 0.0537 μs | 0.0502 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.656 μs | 0.0258 μs | 0.0241 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.332 μs | 0.0054 μs | 0.0051 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.754 μs | 0.0090 μs | 0.0084 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.906 μs | 0.0045 μs | 0.0042 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.911 μs | 0.0043 μs | 0.0040 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  54.506 μs | 0.0923 μs | 0.0863 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  61.416 μs | 0.2369 μs | 0.2216 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.741 μs | 0.1957 μs | 0.1831 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.715 μs | 0.1704 μs | 0.1594 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.347 μs | 0.0898 μs | 0.0840 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.783 μs | 0.0428 μs | 0.0400 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 695.586 μs | 1.0547 μs | 0.9866 μs |      56 B |