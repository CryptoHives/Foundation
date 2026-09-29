| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |         76.29 ns |      0.081 ns |      0.076 ns |   2,891 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |         80.91 ns |      0.058 ns |      0.048 ns |   2,979 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         94.16 ns |      0.169 ns |      0.150 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         96.23 ns |      0.238 ns |      0.211 ns |   6,643 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        100.80 ns |      0.070 ns |      0.062 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         79.02 ns |      0.051 ns |      0.047 ns |   2,911 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |         80.48 ns |      0.046 ns |      0.043 ns |   2,999 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         91.53 ns |      0.161 ns |      0.151 ns |   6,663 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         93.15 ns |      0.161 ns |      0.135 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        100.74 ns |      0.081 ns |      0.076 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        154.39 ns |      0.072 ns |      0.067 ns |   2,928 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        161.40 ns |      0.074 ns |      0.069 ns |   3,002 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        173.30 ns |      0.118 ns |      0.110 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        181.56 ns |      0.377 ns |      0.334 ns |   6,666 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        184.31 ns |      0.095 ns |      0.079 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        150.26 ns |      0.097 ns |      0.090 ns |   2,913 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        157.29 ns |      0.180 ns |      0.169 ns |   3,001 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        173.56 ns |      0.100 ns |      0.093 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        177.77 ns |      0.156 ns |      0.139 ns |   6,654 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        184.39 ns |      0.125 ns |      0.116 ns |   6,330 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        228.73 ns |      0.085 ns |      0.079 ns |   2,914 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        237.79 ns |      0.165 ns |      0.155 ns |   3,019 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        253.77 ns |      0.222 ns |      0.207 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        266.24 ns |      0.451 ns |      0.422 ns |   6,684 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        268.39 ns |      0.112 ns |      0.100 ns |   6,342 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,181.88 ns |      0.471 ns |      0.441 ns |   2,909 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,227.34 ns |      0.423 ns |      0.353 ns |   2,997 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,271.54 ns |      0.311 ns |      0.291 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,361.90 ns |      0.527 ns |      0.440 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,387.87 ns |      2.250 ns |      2.104 ns |   6,654 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,262.52 ns |      0.619 ns |      0.579 ns |   2,924 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,308.50 ns |      1.154 ns |      1.079 ns |   3,001 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,347.94 ns |      1.119 ns |      1.047 ns |   5,859 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,441.78 ns |      0.517 ns |      0.459 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,471.64 ns |      2.810 ns |      2.628 ns |   6,665 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |      9,456.15 ns |      5.017 ns |      4.693 ns |   3,145 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |      9,796.15 ns |      4.680 ns |      4.377 ns |   3,233 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     10,047.41 ns |      5.206 ns |      4.869 ns |   5,885 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     10,711.16 ns |      6.144 ns |      5.446 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     11,069.69 ns |     28.839 ns |     26.976 ns |   6,668 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     75,979.31 ns |     46.244 ns |     43.257 ns |   3,145 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |     78,345.55 ns |     45.917 ns |     42.951 ns |   3,247 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     80,019.32 ns |     42.397 ns |     39.658 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     85,563.67 ns |     17.821 ns |     15.798 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     88,817.50 ns |    150.750 ns |    133.636 ns |   6,897 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    150,921.23 ns |     69.508 ns |     61.617 ns |   3,152 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    156,241.42 ns |     52.853 ns |     49.439 ns |   3,233 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    160,043.08 ns |     75.496 ns |     70.619 ns |   6,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    171,329.78 ns |     35.312 ns |     29.487 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    177,063.43 ns |    352.214 ns |    329.462 ns |   6,897 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,160,469.22 ns |    616.667 ns |    576.831 ns |   3,145 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,195,124.64 ns |    402.908 ns |    376.881 ns |   3,240 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,224,964.66 ns |    606.819 ns |    537.929 ns |   6,132 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,305,511.32 ns |    460.648 ns |    430.890 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,352,243.40 ns |  4,319.012 ns |  4,040.006 ns |   6,904 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 11,519,050.60 ns |  6,318.916 ns |  5,276.581 ns |   3,174 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 11,956,501.79 ns |  4,638.466 ns |  4,111.879 ns |   3,240 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 12,251,160.42 ns |  3,663.680 ns |  3,427.008 ns |   6,132 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 13,109,079.84 ns |  6,206.478 ns |  5,805.543 ns |   6,342 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 13,443,099.00 ns | 28,066.836 ns | 24,880.519 ns |   6,904 B |         - |