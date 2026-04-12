| Description                                             | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128B         |     158.8 ns |      1.00 ns |      0.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128B         |     159.6 ns |      1.93 ns |      1.71 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     161.4 ns |      1.43 ns |      1.33 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128B         |     162.1 ns |      1.07 ns |      0.89 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     163.1 ns |      0.88 ns |      0.82 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     621.7 ns |      6.78 ns |      6.01 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     231.3 ns |      1.05 ns |      0.93 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 137B         |     241.3 ns |      1.80 ns |      1.60 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 137B         |     241.8 ns |      2.44 ns |      2.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     244.6 ns |      2.52 ns |      2.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 137B         |     246.8 ns |      1.54 ns |      1.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     921.1 ns |     13.51 ns |     11.97 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,143.7 ns |      4.06 ns |      3.17 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1KB          |   1,225.4 ns |      7.05 ns |      6.60 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1KB          |   1,237.7 ns |     18.57 ns |     17.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,248.2 ns |     18.62 ns |     16.50 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1KB          |   1,250.7 ns |      8.35 ns |      7.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   4,826.7 ns |     84.65 ns |     75.04 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,219.8 ns |      6.91 ns |      6.12 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1025B        |   1,307.0 ns |      7.12 ns |      6.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,311.9 ns |     10.46 ns |      9.78 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1025B        |   1,315.7 ns |     18.13 ns |     16.07 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1025B        |   1,331.3 ns |      5.77 ns |      5.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   5,169.3 ns |     99.74 ns |    122.49 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   9,045.1 ns |     57.81 ns |     51.25 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |   9,644.7 ns |     63.13 ns |     59.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 8KB          |   9,763.7 ns |     56.90 ns |     53.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 8KB          |   9,862.9 ns |    117.12 ns |    109.55 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 8KB          |   9,901.2 ns |     20.29 ns |     16.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |  38,853.8 ns |    743.26 ns |    695.25 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 143,943.4 ns |    831.40 ns |    777.69 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 153,208.5 ns |    651.61 ns |    544.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128KB        | 156,384.4 ns |  1,116.15 ns |  1,044.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128KB        | 158,555.7 ns |    659.61 ns |    584.72 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128KB        | 158,780.4 ns |  1,952.04 ns |  1,825.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 624,052.7 ns | 11,940.72 ns | 13,272.07 ns |         - |