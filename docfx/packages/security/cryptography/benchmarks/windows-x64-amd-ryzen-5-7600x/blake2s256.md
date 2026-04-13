| Description                                             | TestDataSize | Mean         | Error        | StdDev       | Median       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     156.6 ns |      0.37 ns |      0.33 ns |     156.7 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128B         |     158.5 ns |      1.66 ns |      1.47 ns |     158.2 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128B         |     158.6 ns |      1.01 ns |      0.95 ns |     158.2 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128B         |     161.7 ns |      0.79 ns |      0.74 ns |     161.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     164.4 ns |      0.99 ns |      0.92 ns |     164.1 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     608.4 ns |     11.91 ns |     11.14 ns |     605.7 ns |         - |
|                                                         |              |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 137B         |     236.3 ns |      1.04 ns |      0.93 ns |     236.1 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     236.5 ns |      0.78 ns |      0.65 ns |     236.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 137B         |     240.2 ns |      0.74 ns |      0.66 ns |     240.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 137B         |     245.1 ns |      0.47 ns |      0.42 ns |     245.1 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     245.8 ns |      0.78 ns |      0.73 ns |     245.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     902.9 ns |     10.98 ns |     10.27 ns |     899.4 ns |         - |
|                                                         |              |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,139.6 ns |      3.53 ns |      3.31 ns |   1,139.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1KB          |   1,214.1 ns |      6.27 ns |      5.56 ns |   1,213.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1KB          |   1,218.0 ns |      2.86 ns |      2.67 ns |   1,217.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,236.3 ns |      3.44 ns |      3.22 ns |   1,236.7 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1KB          |   1,241.1 ns |      1.82 ns |      1.61 ns |   1,240.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   4,708.6 ns |     41.92 ns |     35.01 ns |   4,701.8 ns |         - |
|                                                         |              |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,211.6 ns |      4.59 ns |      4.29 ns |   1,211.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1025B        |   1,288.9 ns |      3.36 ns |      3.14 ns |   1,289.4 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1025B        |   1,299.5 ns |      1.97 ns |      1.84 ns |   1,299.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,308.3 ns |      3.27 ns |      3.06 ns |   1,308.4 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1025B        |   1,324.3 ns |      2.47 ns |      2.19 ns |   1,323.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   5,049.8 ns |     98.97 ns |    125.16 ns |   4,966.7 ns |         - |
|                                                         |              |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   9,003.7 ns |     36.97 ns |     34.59 ns |   9,009.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |   9,635.8 ns |     12.36 ns |     11.56 ns |   9,635.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 8KB          |   9,649.5 ns |     54.84 ns |     48.61 ns |   9,647.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 8KB          |   9,699.1 ns |     20.17 ns |     18.87 ns |   9,699.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 8KB          |   9,887.2 ns |     25.60 ns |     23.95 ns |   9,879.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |  37,626.0 ns |    591.61 ns |    581.04 ns |  37,295.5 ns |         - |
|                                                         |              |              |              |              |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 144,182.1 ns |    618.48 ns |    548.27 ns | 144,159.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 154,148.3 ns |    457.19 ns |    405.29 ns | 154,151.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128KB        | 154,326.0 ns |    694.05 ns |    615.26 ns | 154,305.7 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128KB        | 154,996.0 ns |    252.75 ns |    236.42 ns | 154,988.1 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128KB        | 158,004.1 ns |    300.37 ns |    280.96 ns | 157,999.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 603,951.1 ns | 11,842.83 ns | 11,077.79 ns | 598,307.6 ns |         - |