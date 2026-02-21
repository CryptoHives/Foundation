| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |     106.35 ns |     0.396 ns |     0.351 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |     106.64 ns |     0.560 ns |     0.496 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 17B          |     119.60 ns |     0.471 ns |     0.418 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 17B          |     366.28 ns |     2.698 ns |     2.524 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 17B          |     618.18 ns |     5.383 ns |     4.772 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |      66.18 ns |     0.186 ns |     0.146 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |      66.69 ns |     0.294 ns |     0.275 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 17B          |     130.98 ns |     1.039 ns |     0.972 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 17B          |     332.10 ns |     1.872 ns |     1.660 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 17B          |     548.02 ns |     5.361 ns |     5.015 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |     106.56 ns |     0.523 ns |     0.489 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |     107.58 ns |     0.380 ns |     0.318 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 65B          |     122.40 ns |     0.434 ns |     0.362 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 65B          |     631.72 ns |     4.488 ns |     4.198 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 65B          |     830.75 ns |     6.901 ns |     6.456 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |      73.52 ns |     0.305 ns |     0.271 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |      73.94 ns |     0.359 ns |     0.318 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 65B          |     130.77 ns |     0.724 ns |     0.604 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 65B          |     606.37 ns |     4.987 ns |     4.665 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 65B          |     728.94 ns |     5.457 ns |     5.104 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |     101.88 ns |     0.612 ns |     0.542 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |     112.41 ns |     0.677 ns |     0.633 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 128B         |     120.86 ns |     0.914 ns |     0.855 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 128B         |     894.22 ns |     5.385 ns |     4.774 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128B         |     991.28 ns |    13.339 ns |    12.477 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      61.31 ns |     0.307 ns |     0.273 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      63.59 ns |     0.454 ns |     0.424 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 128B         |     121.47 ns |     0.860 ns |     0.805 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 128B         |     861.09 ns |     5.235 ns |     4.897 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128B         |     898.99 ns |     5.636 ns |     5.271 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |     125.74 ns |     1.270 ns |     1.188 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |     130.75 ns |     1.391 ns |     1.233 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 152B         |     139.64 ns |     0.699 ns |     0.654 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 152B         |   1,076.93 ns |     7.339 ns |     6.865 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,132.46 ns |    12.250 ns |    11.459 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |      87.87 ns |     0.216 ns |     0.202 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |      90.30 ns |     0.470 ns |     0.439 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 152B         |     140.31 ns |     1.010 ns |     0.945 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,022.53 ns |     6.616 ns |     6.188 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 152B         |   1,043.56 ns |     8.347 ns |     7.808 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |     115.62 ns |     0.529 ns |     0.469 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |     129.00 ns |     0.629 ns |     0.558 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 256B         |     129.59 ns |     0.748 ns |     0.700 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,452.83 ns |     7.356 ns |     6.142 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 256B         |   1,597.47 ns |    11.221 ns |    10.496 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |      79.27 ns |     0.185 ns |     0.145 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |      83.54 ns |     0.301 ns |     0.281 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 256B         |     124.00 ns |     1.186 ns |     1.110 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,354.88 ns |     8.557 ns |     7.586 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 256B         |   1,559.70 ns |     8.748 ns |     7.755 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 1KB          |     193.11 ns |     1.466 ns |     1.371 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     210.22 ns |     1.089 ns |     1.019 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     259.33 ns |     1.614 ns |     1.431 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,254.06 ns |    33.830 ns |    31.644 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 1KB          |   5,839.03 ns |    67.090 ns |    56.023 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 1KB          |     178.61 ns |     1.091 ns |     1.021 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     189.40 ns |     1.049 ns |     0.876 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     211.37 ns |     1.152 ns |     1.078 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,135.43 ns |    31.423 ns |    29.393 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 1KB          |   5,814.57 ns |    36.516 ns |    34.157 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 8KB          |     783.56 ns |     4.486 ns |     4.196 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,082.11 ns |     5.773 ns |     5.118 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,477.30 ns |    10.369 ns |     9.192 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,988.30 ns |   219.958 ns |   205.749 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 8KB          |  45,287.45 ns |   241.990 ns |   188.930 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 8KB          |     717.85 ns |     6.793 ns |     6.022 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,207.83 ns |     8.874 ns |     7.866 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,379.39 ns |     9.656 ns |     8.063 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,911.50 ns |   173.018 ns |   161.841 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 8KB          |  45,179.98 ns |   247.223 ns |   219.157 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 128KB        |  11,802.50 ns |   104.681 ns |    92.797 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  16,775.52 ns |   239.921 ns |   224.422 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  22,434.75 ns |   211.146 ns |   197.506 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 472,739.07 ns | 2,857.886 ns | 2,533.441 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 128KB        | 720,089.67 ns | 4,794.566 ns | 4,250.258 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 128KB        |  10,210.37 ns |    80.029 ns |    74.859 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  18,749.01 ns |   223.366 ns |   208.937 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  21,550.17 ns |   152.205 ns |   127.098 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 473,107.47 ns | 2,064.949 ns | 1,724.326 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 128KB        | 719,806.67 ns | 5,262.788 ns | 4,394.667 ns |         - |